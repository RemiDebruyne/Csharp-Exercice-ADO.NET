using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceCommande.Classes
{
    internal class Client
    {
        public int Id { get; set; }
        public string Prenom{ get; set; }
        public string Nom{ get; set; }
        public string Adresse{ get; set; }
        public string CodePostal{ get; set; }
        public string Ville{ get; set; }
        public string Telephone{ get; set; }
        public List<Commande> Commandes { get; set; }

        public Client(int id, string prenom, string nom, string adresse, string codePostal, string ville, string telephone)
        {
            Id = id;
            Prenom = prenom;
            Nom = nom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"id {Id}, nom: {Nom.ToUpper()}, prenom: {Prenom}, adresse: {Adresse}, code postale: {CodePostal}, ville: {Ville}, telephone: {Telephone}";
        }
    }
}
