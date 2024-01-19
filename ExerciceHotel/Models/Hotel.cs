using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
    internal class Hotel
    {
        public List<Chambre> listeChambre { get; set; }
        public List<Client> listeClient { get; set; }
        public List<Reservation> listeReservation { get; set; }

    }
}
