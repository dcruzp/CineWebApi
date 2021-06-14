using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineWebApi.Data;
using CineWebApi.DBModels;
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

        // GET: api/<EntradasController>
        [HttpGet]
        public async Task<ActionResult<Entradum[]>>  Get()
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

        [HttpGet("{min_price:decimal}")]
        public async Task<ActionResult<Entradum[]>> Get (decimal min_price = 0,
                                                         decimal max_price = decimal.MaxValue)
        {
            try
            {
                var entradas = await _repository.GetAllEntradasAsync(min_price: min_price,
                                                                     max_price: max_price,
                                                                     min_datetime: DateTime.Now,
                                                                     max_datetime: DateTime.MaxValue);

                return entradas; 
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entradum>> Get([FromQuery]Guid id)
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
        public async Task<ActionResult<Entradum>> Delete(Guid id)
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
