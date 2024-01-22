<<<<<<< HEAD
﻿using ExerciceHotel.Enumarable;
using System;
=======
﻿using System;
>>>>>>> cfb5d691bac389cc282fec6bddcd2cff75e2a026
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using ExerciceHotel.Enums;
>>>>>>> cfb5d691bac389cc282fec6bddcd2cff75e2a026

namespace ExerciceHotel.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public StatusReservation Status { get; set; }

        public List<Chambre> listeChambre { get; set; }
        public Client Client { get; set; }

        public int Client_id { get; set; }


=======
        public StatusReservation StatusReservation { get; set; }
        public List<Chambre> listeChambre { get; set;}
        public Client client { get; set; }
>>>>>>> cfb5d691bac389cc282fec6bddcd2cff75e2a026
    }
}
