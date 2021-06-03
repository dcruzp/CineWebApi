using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineWebApi.Data;
using CineWebApi.DBModels;
using CineWebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("React_Policy")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public PeliculaController(IPeliculaRepository repository, IMapper mapper , LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        // GET: api/<PeliculaController>
        [HttpGet]
        public async Task<ActionResult<PeliculaModels[]>> Get()
        {
            try
            {
                var models = await _repository.GetAllPeliculasAsync();

                return _mapper.Map<PeliculaModels[]>(models);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{titulo}")]
        public async Task<ActionResult<PeliculaModels>> Get(string titulo)
        {
            try
            {
                var models = await _repository.GetPeliculaAsync(titulo);

                return _mapper.Map<PeliculaModels>(models);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // POST api/<PeliculaController>
        [HttpPost]
        public async Task<ActionResult<PeliculaModels>> Post([FromBody] PeliculaModels pelicula)
        {
            try
            {
                var existPelicula = await _repository.GetPeliculaAsync(pelicula.Titulo);
                if (existPelicula != null) return BadRequest("Film in use");

                var location = _linkGenerator.GetPathByAction(
                    "Get",
                    "Pelicula",
                    new { pelicula.Titulo });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current Pelicula");
                }

                var model = _mapper.Map<Pelicula>(pelicula);

                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/pelicula/{model.Titulo}", _mapper.Map<PeliculaModels>(model));
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest();
        }

        // PUT api/<PeliculaController>/5
        [HttpPut("{title}")]
        public async Task<ActionResult<PeliculaModels>> Put(string title, [FromBody] PeliculaModels pelicula)
        {
            try
            {
                var oldfilm = await _repository.GetPeliculaAsync(title);
                if (oldfilm == null) return NotFound($"Could not found film with title of {title}");

                _mapper.Map(pelicula, oldfilm); 

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<PeliculaModels>(oldfilm); 
                }
            }
            catch 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest(); 
        }

        // DELETE api/<PeliculaController>/5
        [HttpDelete("{title}")]
        public async Task<ActionResult<PeliculaModels>> Delete(string title)
        {
            try
            {
                var oldfilm = await _repository.GetPeliculaAsync(title);
                if (oldfilm == null) return NotFound();

                _repository.Delete(oldfilm); 

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(); 
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest("Failed to delete the film"); 
        }
    }
}
