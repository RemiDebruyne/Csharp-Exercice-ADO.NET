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
    internal class Chambre
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public StatusChambre Status { get; set; }
        public int NombreLit { get; set; }
        public int Prix { get; set; }
        public Client Client { get; set; }

        public int Client_id { get; set; }
    }
=======

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


>>>>>>> cfb5d691bac389cc282fec6bddcd2cff75e2a026
}
