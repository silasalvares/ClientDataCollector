using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace robot.Database
{
    public class DB_Context : DbContext 
    {
        private const string connectionString = "Server=localhost;Database=clients;User Id=sa;Password=Mssql2019;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<ClientData> ClientData { get; set; }
    }

}