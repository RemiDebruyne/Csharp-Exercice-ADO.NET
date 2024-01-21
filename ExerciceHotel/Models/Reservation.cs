using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Enums;

namespace ExerciceHotel.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
        public StatusReservation StatusReservation { get; set; }
        public List<Chambre> listeChambre { get; set;}
        public Client client { get; set; }
    }
}
