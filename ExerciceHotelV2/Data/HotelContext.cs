using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotelV2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciceHotelV2.Data
{
    internal class HotelContext : DbContext
    {
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public HotelContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\exerciceDB;Initial Catalog=ExerciceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; ExerciceDB");

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\exerciceDB;Initial Catalog=ExericeHotelV2;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; Database=exerciceHotelV2;");

        }
    }
}
