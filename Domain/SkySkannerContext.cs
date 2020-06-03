using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Domain
{
    public class SkySkannerContext : DbContext
    {
        private static readonly string connectionString = "DataSource=.;Initial Catalog = SkySkanner;Integrated Security=True;";
        //DataSource określa adres serwera (po IP), jeśli kropka - lokalnie działająca maszyna 
        //Initial Catalog to nazwa bazy danych
        //Integrated Security=True; autoryzuje działania na bazie danych(daje programowi dostęp), albo odwrotnie

        public DbSet<Airport> Airports { get; set; }
        public DbSet<PlaneModel> PlaneModels { get; set; }
        public DbSet<AirConnection> AirConnections { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
