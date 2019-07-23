using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public ActionResult<string> Post([FromBody] ClientData clientData)
        {
            ClientData client = new ClientData() {
                ip = clientData.ip,
                page = clientData.page,
                browser = clientData.browser,
                parameters = clientData.parameters
            };
            db.ClientData.Add(client);
            db.SaveChanges();
            return "Created";
        } 
    }
}