using Azure.Core;
using ExerciceAdo.Classes;
using Microsoft.Data.SqlClient;

// connectionString
string connectionString = "Data Source=(localdb)\\exerciceDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; Database = contactDB";



Console.WriteLine("Que voulez vous faire ? \n" +
    "1. Ajouter un étudiant\n" +
    "2. Afficher la totalité des étudiants\n" +
    "3. Afficher les étudiants d'une classe\n" +
    "4. Supprimer un étudiant\n" +
    "5. Mettre à jour un étudiant\n" +
    "0. Quitter");

switch (Console.ReadLine())
{
    case "1":
        Console.Write("Quelle est le nom de l'étudiant : ");
        string nom = Console.ReadLine();

        Console.Write("Quelle est son prénom : ");
        string prenom = Console.ReadLine();

        Console.Write("Quelle est son numéro de classe : ");
        int classNb = int.Parse(Console.ReadLine());

        Console.Write("Quelle est la date d'obtention de son diplome (format : aaaa-mm-jj) : ");
        DateOnly dateDiplome = DateOnly.Parse(Console.ReadLine());

        Etudiant etudiant = new Etudiant(nom, prenom, classNb, dateDiplome);

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string request = $"INSERT INTO etudiants (prenom, nom, numero_de_classe, date_diplome) VALUES(@prenom, @nom, @numero_de_classe, @date_diplome)";
            SqlCommand command = new  SqlCommand(request, conn);
            command.Parameters.AddWithValue($"@prenom", prenom);
            command.Parameters.AddWithValue($"@nom", nom);
            command.Parameters.AddWithValue($"@numero_de_classe", classNb);
            command.Parameters.AddWithValue($"@date_diplome", dateDiplome);
        }
        break;
    case "2":
        break;
    case "3":
        break;
    case "4":
        break;
    case "5":
        break;
    case "0":
        break;
    default:
        Console.WriteLine("Valeur incorrecte");
        break;

}
