using ExerciceHotelV2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotelV2.Models
{
    internal class Chambre
    {
        private static int NbChambre = 0;
        private Random rnd = new Random();
        public int Id { get; set; }
        public StatusChambre StatusChambre { get; set; }
        public int NombreLit { get; set; }
        public float Prix { get; set; }
        public List<Reservation>? Reservation { get; set; }


        public Chambre()
        {
            Id = NbChambre++;
            StatusChambre = StatusChambre.LIBRE;
            NombreLit = rnd.Next(1, 5);
            Prix = 250;
        }
    }
}
