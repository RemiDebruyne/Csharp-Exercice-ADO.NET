using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceCommande.Classes
{
    internal class Commande
    {

        public int Id { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public decimal PrixTotal { get; set; }

        public Commande(int id, DateTime date, decimal prixTotal)
        {
            Id = id;
            Date = date;
            PrixTotal = prixTotal;
        }
    }
}
