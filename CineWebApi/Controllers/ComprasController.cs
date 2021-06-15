using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CineWebApi.DBModels;
using System.Threading.Tasks;

namespace CineWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {

        // GET: api/<ComprasController>
        [HttpGet]
        public async Task<ActionResult<Compra[]>> Get()
        {
            try
            {

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

    }      
    
}
