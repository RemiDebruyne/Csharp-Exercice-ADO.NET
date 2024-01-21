using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciceHotel.Data
{
    internal class HotelDbContext : DbContext
    {
        //public DbSet<Hotel> Hotels { get; set; }
        //public DbSet<Chambre> Chambres { get; set; }
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }

        public HotelDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\exerciceDB;Initial Catalog=ExerciceDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; ExerciceDB");
        }
    }
}
