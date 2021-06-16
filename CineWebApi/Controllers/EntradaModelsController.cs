using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CineWebApi.Data;
using CineWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaModelsController : ControllerBase
    {

        private readonly IEntradasModelsRepository _repository; 

        public EntradaModelsController(IEntradasModelsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ModelEntradaController>
        //[HttpGet]
        //public async Task<ActionResult<EntradaModels>> Get()
        //{
        //    try
        //    {
        //        return Ok();
        //    }
        //    catch 
        //    {

        //        throw;
        //    }
        //}

        // GET api/<ModelEntradaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntradaModels>>  Get(Guid id)
        {
            try
            {
                var models = await _repository.GetEntradaModelsByPelicula(id);

                return models; 
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure"); 
            }
        }

        // POST api/<ModelEntradaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ModelEntradaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModelEntradaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
