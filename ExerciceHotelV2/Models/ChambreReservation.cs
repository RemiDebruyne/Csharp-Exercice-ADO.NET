using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotelV2.Models
{
    internal class ChambreReservation
    {
        public int ChambreId { get; set; }
        public int ReservationId {  get; set; }
        public Chambre Chambre {  get; set; }
        public Reservation Reservation { get; set; }
    }
}
