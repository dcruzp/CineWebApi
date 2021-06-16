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
    [Route("api/entradas/{identrada}/compras/")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly IComprasRepository _repository;

        public ComprasController(IComprasRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ComprasController>
        [HttpGet]
        public async Task<ActionResult<Compra[]>> Get(Guid identrada)
        {
            try
            {
                var compras = await _repository.GetComprasByEntradaAsync(identrada);

                return compras; 
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetComprasById(Guid id)
        {
            try
            {
                var compra = await _repository.GetCompraByIdAsync(id);

                return compra;
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
