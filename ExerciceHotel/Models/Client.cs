using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
    internal class Client
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }

        public List<Chambre> listeChambre { get; set; }
=======


        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public List<Reservation> listeReservation { get; set; }

        public Client(string prenom, string nom, string telephone)
        {
            Prenom = prenom;
            Nom = nom;
            Telephone = telephone;
            listeReservation = new List<Reservation>();
        }
        public Client(int id, string prenom, string nom, string telephone, List<Reservation> reservation)
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
            Telephone = telephone;
            listeReservation = reservation;
        }
>>>>>>> cfb5d691bac389cc282fec6bddcd2cff75e2a026

    }
}
