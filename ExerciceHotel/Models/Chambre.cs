using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceHotel.Enums;

namespace ExerciceHotel.Models
{
    internal class Chambre
    {

        private Random rnd = new Random();
        public int Id { get; set; }
        public StatusChambre StatusChambre { get; set; } = StatusChambre.LIBRE;
        public int NombreLit { get; set; }
        public decimal Prix { get; set; }
        public Reservation? Reservation { get; set; }

        public int ReservationId { get; set; }

        public Chambre()
        {
            NombreLit = rnd.Next(1, 5);
        }

    }


}
