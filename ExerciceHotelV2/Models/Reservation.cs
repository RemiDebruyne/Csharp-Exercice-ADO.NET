using ExerciceHotelV2.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotelV2.Models
{
    internal class Reservation
    {
        private static int NbReservation;
        public int Id { get; set; }
        public StatusReservation Status { get; set; }
        public List<Chambre> ListeChambre { get; set; }
        public Client Client { get; set; }
        public int ClientId {  get; set; }

        public Reservation()
        {
        }

        public Reservation(List<Chambre> listeChambre, Client client)
        {
            Id = NbReservation++;
            Status = StatusReservation.PREVU;
            ListeChambre = listeChambre;
            Client = client;
            ClientId = client.Id;
        }
    }
}
