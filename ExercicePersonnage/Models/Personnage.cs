using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicePersonnage.Models
{
    internal class Personnage
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public int Pv { get; set; }
        public int Armure { get; set; }
        public int Dmg { get; set; }
        public DateTime CreationDate { get; set; }
        public int Kill { get; set; }



    }
}
