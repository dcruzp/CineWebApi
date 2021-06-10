using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineWebApi.Data;
using CineWebApi.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly ISalasRepository _repository; 

        public SalasController(ISalasRepository repository)
        {
            _repository = repository; 
        }

        // GET: api/<SalasController>
        [HttpGet]
        public async Task<ActionResult<Sala[]>> Get()
        {
            try
            {
                var salas = await _repository.GetAllSalasAsync();

                return salas; 
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure"); 
            }
        }

        // GET api/<SalasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> Get(Guid id)
        {
            try
            {
                var sala = await _repository.GetSalaAsync(id);

                return sala; 
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        // POST api/<SalasController>
        [HttpPost]
        public async Task<ActionResult<Sala>> Post([FromBody] Sala sala)
        {
            try
            {
                _repository.Add(sala); 

                if (await _repository.SaveChangesAsync())
                {
                    return Created("api/", sala); 
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Databasa Failure"); 
            }
            return BadRequest("Cant not insert the  sala into de database"); 
        }

        // PUT api/<SalasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
