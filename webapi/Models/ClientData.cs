using Microsoft.EntityFrameworkCore;

namespace webapi.Models
{
    public class ClientData
    {
        public int id { get; set; } 
        public string ip { get; set; }
        public string page { get; set; }
        public string browser { get; set; }
        public string parameters { get; set; }
    }
}