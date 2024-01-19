using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicePersonnage.Models;


namespace ExercicePersonnage.Data
{
    internal class PersonnageContext : DbContext
    {
        public PersonnageContext() : base()
        {
        }

        public DbSet<Personnage> Personnages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\exerciceDB02; Database=exercicePersonnage;");
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\exerciceDB; Database=exercicePersonnage;");
        }
    }
}
