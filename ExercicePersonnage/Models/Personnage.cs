using ExercicePersonnage.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ExercicePersonnage.Models
{
    internal class Personnage
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public int Pv { get; set; }
        public int Armure { get; set; }
        public int Dmg { get; set; }
        public DateTime CreationDate { get; set; }
        public int Kill { get; set; }




        public Personnage GetPersonnageByPseudo(string pseudo)
        {
            using var context = new PersonnageContext();

            Personnage personnage = context.Personnages.Where(p => p.Pseudo == pseudo).FirstOrDefault();

            return personnage;
        }

        public void GetAllPersonnages()
        {
            using var context = new PersonnageContext();

            context.Personnages.ToList().ForEach(personnage => Console.WriteLine(personnage));
        }
        public Personnage UpdatePersonnage(Personnage personnage, string newValue)
        {
            using var context = new PersonnageContext();

            personnage.Pseudo = newValue;

            context.SaveChanges();

            return personnage;

        }

        public override string ToString()
        {
            return @$"Pseudo: {Pseudo}
PV: {Pv}
Armure: {Armure}
Kill: {Kill}
Date de création: {CreationDate}";
        }
    }
}
