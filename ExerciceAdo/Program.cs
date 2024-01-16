using Azure.Core;
using ExerciceAdo.Classes;
using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

// connectionString
string connectionString = "Data Source=(localdb)\\exerciceDB;Initial Catalog=exercice01;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=True; Database = exercice01";



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
        Console.Write("Quelle est son prénom : ");
        string prenom = Console.ReadLine();

        Console.Write("Quelle est le nom de l'étudiant : ");
        string nom = Console.ReadLine();

        Console.Write("Quelle est son numéro de classe : ");
        int classNb = int.Parse(Console.ReadLine());

        Console.Write("Quelle est la date d'obtention de son diplome (format : aaaa-mm-jj) : ");
        DateOnly dateDiplome = DateOnly.Parse(Console.ReadLine());

        Etudiant etudiant = new Etudiant(nom, prenom, classNb, dateDiplome);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string request = $"INSERT INTO etudiants (prenom, nom, numero_de_classe, date_diplome) VALUES(@prenom, @nom, @numero_de_classe, @date_diplome)";
            SqlCommand command = new SqlCommand(request, connection);
            command.Parameters.AddWithValue($"@prenom", prenom);
            command.Parameters.AddWithValue($"@nom", nom);
            command.Parameters.AddWithValue($"@numero_de_classe", classNb);
            command.Parameters.AddWithValue($"@date_diplome", dateDiplome);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} lignes affectées");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        break;
    case "2":
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string request = "SELECT * FROM etudiants";
            SqlCommand command = new SqlCommand(request, connection);
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Console.WriteLine($" id: {reader.GetInt32(0)}, prenom: {reader.GetString(1)}, nom: {reader.GetString(2)},numero_de_classe: {reader.GetInt32(3)}, date_diplome: {reader.GetDateTime(4)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        break;
    case "3":
        Console.Write("De quelle classe voulez-vous voir la liste d'étudiants ? : ");
        int input = int.Parse(Console.ReadLine());

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string request = $"SELECT * FROM etudiants WHERE numero_de_classe = {input}";

            SqlCommand command = new(request, connection);
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Console.WriteLine($" id: {reader.GetInt32(0)}, prenom: {reader.GetString(1)}, nom: {reader.GetString(2)}, date_diplome: {reader.GetDateTime(4)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        break;
    case "4":
        Console.Write("Vous voulez éradiquer un étudiant de l'existence ? Quelle est son prénom ? : ");
        string prenomnomEtudiantASuprimmer = Console.ReadLine();

        Console.Write("Quel est son nom ? : ");
        string nomEtudiantASuprimmer = Console.ReadLine();


        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string request = $"DELETE FROM etudiants where prenom = '{prenomnomEtudiantASuprimmer}' AND nom = '{nomEtudiantASuprimmer}'";

            SqlCommand command = new(request, connection);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} lignes affectées");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        break;
    case "5":

        break;
    case "0":
        Environment.Exit(0);
        break;
    default:
        Console.WriteLine("Valeur incorrecte");
        break;

}
