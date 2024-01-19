using ExerciceHotel.Enumarable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
    internal class Chambre
    {
        public int Id { get; set; }
        public StatusChambre Status { get; set; }
        public int NombreLit { get; set; }
        public int Prix { get; set; }
        public Client Client { get; set; }

        public int Client_id { get; set; }
    }
}
