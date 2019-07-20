using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Repository;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientDataController : ControllerBase
    {
        private DB_Context db;

        public ClientDataController(DB_Context _db)
        {
            db = _db;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            ClientData client = new ClientData() {
                ip = "123456"
            };
            db.ClientData.Add(client);
            db.SaveChanges();
            
            return "TesteGet";
        } 

        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            return "Teste";
        } 
    }
}