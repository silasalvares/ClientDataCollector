using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Repository
{
    public class DB_Context : DbContext 
    {
        public DB_Context(DbContextOptions<DB_Context> options):base(options)
        {

        }

        public DbSet<ClientData> ClientData { get; set; }
    }

}