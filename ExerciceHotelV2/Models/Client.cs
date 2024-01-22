using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotelV2.Models
{
    internal class Client
    {
        private static int NbClient;
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public List<Reservation> listeReservation { get; set; }

        public Client(string prenomn, string nom, string telephone)
        {
            Id = NbClient++;
            Prenom = prenomn;
            Nom = nom;
            Telephone = telephone;
            listeReservation = new List<Reservation>();
        }

        public Client()
        {

        }
    }
}
