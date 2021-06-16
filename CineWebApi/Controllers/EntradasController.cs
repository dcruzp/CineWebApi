using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineWebApi.Data;
using CineWebApi.DBModels;
using CineWebApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EntradasController : ControllerBase
    {
        private readonly IEntradaRepository _repository;
        public EntradasController(IEntradaRepository repository)
        {
            _repository = repository;
        }

        //GET: api/<EntradasController>
        [HttpGet]
        public async Task<ActionResult<Entradas[]>> Get()
        {
            try
            {
                var entradas = await _repository.GetAllEntradasAsync();

                return entradas;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<Entradas[]>> Get([FromQuery] EntradaQueryModels query)
        {
            try
            {


                var entradas = await _repository.GetAllEntradasAsync(min_price: query.minPrice,
                                                                     max_price: query.maxPrice,
                                                                     min_datetime: query.minDatetime,
                                                                     max_datetime: query.maxDatetime,
                                                                     idpelicula: query.idPelicula,
                                                                     nombrePelicula: query.nombrePelicula,
                                                                     idSala: query.idSala,
                                                                     nombreSala: query.nombreSala
                                                                     );

                return entradas;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entradas>> Get([FromQuery]Guid id)
        {
            try
            {
                var entrada = await _repository.GetEntradaAsync(id);

                return entrada; 
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<EntradasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EntradasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entradas>> Delete(Guid id)
        {
            try
            {
                var entrada = _repository.GetEntradaAsync(id); 
                if (entrada == null)
                {
                    return NotFound($"Could not find Entrada with id {id.ToString()}");
                }

                if (await _repository.SaveChangesAsync())
                {
                    return Ok(); 
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest($"Could not delete Entrada with id {id.ToString()}"); 
        }
    }
}
