using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceAdo.Classes
{
    internal class IHM
    {
        public static void Menu()
        {
            int input;
            HashSet<Etudiant> maListe;

            Console.WriteLine("Que voulez vous faire ? \n" +
    "1. Ajouter un étudiant\n" +
    "2. Afficher la totalité des étudiants\n" +
    "3. Afficher les étudiants d'une classe\n" +
    "4. Supprimer un étudiant\n" +
    "5. Mettre à jour un étudiant\n" +
    "6. Trouver un étudiant par son id\n" +
    "0. Quitter");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Quelle est son prénom : ");
                    string prenom = Console.ReadLine();

                    Console.Write("Quelle est le nom de l'étudiant : ");
                    string nom = Console.ReadLine();

                    Console.Write("Quelle est son numéro de classe : ");
                    int classNb = int.Parse(Console.ReadLine());

                    Console.Write("Quelle est la date d'obtention de son diplome (format : aaaa-mm-jj) : ");
                    string dateDiplome = Console.ReadLine();

                    Etudiant.AddEtudiant(prenom, nom, classNb, dateDiplome);

                    break;
                case "2":
                    maListe = Etudiant.GetAllEtudiant();
                    foreach(Etudiant etudiant in maListe )
                    {
                        Console.WriteLine(etudiant);
                    }
                    break;
                case "3":
                    Console.Write("De quelle classe voulez-vous voir la liste d'étudiants ? : ");
                    input = int.Parse(Console.ReadLine());
                    maListe = Etudiant.GetEtudiantByClass(input);

                    foreach(Etudiant etudiant in maListe)
                    {
                        Console.WriteLine(etudiant);
                    }

                    break;
                case "4":
                    Etudiant.Delete();
                    break;
                case "5":

                    break;
                case "6":
                    Console.Write("Quel est l'id de l'étudiant que vous recherchez ? : ");
                    input = int.Parse(Console.ReadLine());
                    Etudiant.GetEtudiantById(input);
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Valeur incorrecte");
                    break;

            }

        }
    }
}
