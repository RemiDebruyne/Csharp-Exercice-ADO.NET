using ExerciceHotel.Enumarable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
        public StatusReservation Status { get; set; }

        public List<Chambre> listeChambre { get; set; }
        public Client Client { get; set; }

        public int Client_id { get; set; }


    }
}
