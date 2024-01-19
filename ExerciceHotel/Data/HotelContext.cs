using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Models;

namespace ExerciceHotel.Data
{
    internal class HotelContext : DbContext
    {
        protected HotelContext() : base()
        {
        }

        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\exerciceDB; Database=exerciceHotel;");
        }

    }
}
