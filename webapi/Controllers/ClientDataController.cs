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
        private IHttpContextAccessor accessor;

        public ClientDataController(DB_Context _db, IHttpContextAccessor _accessor)
        {
            db = _db;
            accessor = _accessor;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            ClientData client = new ClientData() {
                ip = accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                page = Request.Path.ToString(),
                browser = Request.Headers["User-Agent"].ToString(),
                parameters = HttpContext.Request.Query["page"]
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