using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceHotel.Models
{
    internal class Client
    {
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }

        public List<Chambre> listeChambre { get; set; }

    }
}
