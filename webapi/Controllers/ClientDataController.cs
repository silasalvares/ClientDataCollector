using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "TesteGet";
        } 

        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            return "Teste";
        } 
    }
}