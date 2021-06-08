using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineWebApi.Data;
using CineWebApi.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly ISociosRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public SociosController(ISociosRepository repository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        // GET: api/<SociosController>
        [HttpGet]
        public async Task<ActionResult<Socio[]>> Get()
        {
            try
            {
                var models = await _repository.GetAllSociosAsync();

                return models; 
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure"); 
            }
        }

        // GET api/<SociosController>/5
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Socio[]>> Get(string nombre)
        {
            try
            {
                var models = await _repository.GetSociosAsync(nombre);

                return models; 
            }
            catch 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // POST api/<SociosController>
        [HttpPost]
        public async Task<ActionResult<Socio>> Post([FromBody] Socio socio)
        {
            try
            {
                var exist = await _repository.GetSociosAsync(socio.Nombre);
                if (exist.Length > 0) return BadRequest("Socio in use");

                var location = _linkGenerator.GetPathByAction(
                    "Get",
                    "Socios",
                    new { socio.Nombre }); 

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could not use current Pelicula");
                }

                _repository.Add(socio); 

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/Socios/{socio.Nombre}", socio); 
                }
            }
            catch 
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest(); 
        }

        // PUT api/<SociosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Socio>> Put(Guid id, [FromBody] Socio socio)
        {
            try
            {
                var oldsocio = await _repository.GetSociosAsync(socio.IdSocio);
                if (oldsocio == null) return NotFound($"Could not found sicio with id of {socio.IdSocio}");

                oldsocio = socio; 

                if (await _repository.SaveChangesAsync())
                {
                    return oldsocio; 
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        // DELETE api/<SociosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Socio>> Delete(Guid id)
        {
            try
            {
                var oldSocio = await _repository.GetSociosAsync(id);
                if (oldSocio == null) return NotFound();

                _repository.Delete(oldSocio);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest("Failed to delete the Socio");
        }
    }
}
