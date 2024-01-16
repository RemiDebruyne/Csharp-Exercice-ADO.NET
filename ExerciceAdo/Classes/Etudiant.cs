using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Azure.Core;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;


namespace ExerciceAdo.Classes
{
    internal class Etudiant
    {
        private static int _nBEtudiants;
        private static string _connectionString = "Data Source=(localdb)\\exerciceDB;Initial Catalog=exercice01;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=True; Database = exercice01";
        private int _id;
        private string _nom;
        private string _prenom;
        private int _classNb;
        private string _dateDiplome;
        //private static HashSet<Etudiant> _mesEtudiants;

        public int Id { get => _id; set => _id = value; }

        public override string ToString()
        {
            return $"id: {_id}\n" +
                $"prenom: {_prenom}\n" +
                $"nom: {_nom}\n" +
                $"class: n°{_classNb}\n" +
                $"date d'obtention du diplome: {_dateDiplome}";
        }
        public static HashSet<Etudiant> GetAllEtudiant()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                HashSet<Etudiant> maListe = new();
                string request = "SELECT * FROM etudiants";
                SqlCommand command = new SqlCommand(request, connection);
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Etudiant etudiant = new(reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
                        //str += $"id: {reader.GetInt32(0)}";
                        //str += $"prenom: {reader.GetString(1)} ";
                        //str += $"nom: {reader.GetString(2)} ";
                        //str += $"numero_de_classe: {reader.GetInt32(3)} ";
                        //str += $"date_diplome: {reader.GetDateTime(4)} ";
                        maListe.Add(etudiant);
                    }

                    return maListe;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }
        public static HashSet<Etudiant> GetEtudiantById(int input)
        {
            HashSet<Etudiant> maListe = new();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string request = $"SELECT * FROM etudiants WHERE id = @id";
                SqlCommand command = new(request, connection);

                command.Parameters.AddWithValue("@numeroClassee", input);

                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Etudiant etudiant = new(reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
                        maListe.Add(etudiant);
                    }

                    return maListe;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;

                }
            }

        }

        public static HashSet<Etudiant> GetEtudiantByClass(int numeroClasse)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                HashSet<Etudiant> maListe = new();
                connection.Open();
                string request = $"SELECT * FROM etudiants WHERE numero_de_classe = @numeroClasse";

                SqlCommand command = new(request, connection);
                command.Parameters.AddWithValue("@numeroClassee", numeroClasse);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Etudiant etudiant = new(reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
                        maListe.Add(etudiant);

                        Console.WriteLine($" id: {reader.GetInt32(0)}, prenom: {reader.GetString(1)}, nom: , numero_de_classe: {reader.GetInt32(2)}, mail: {reader.GetString(3)}");
                    }

                    return maListe;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }


        public static void AddEtudiant(string prenom, string nom, int classNb, string dateDiplome)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
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
        }


        public static bool Delete()
        {
            Console.Write("Vous voulez éradiquer un étudiant de l'existence ? Quelle est son prénom ? : ");
            string prenomnomEtudiantASuprimmer = Console.ReadLine();

            Console.Write("Quel est son nom ? : ");
            string nomEtudiantASuprimmer = Console.ReadLine();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string request = $"DELETE FROM etudiants where prenom = '{prenomnomEtudiantASuprimmer}' AND nom = '{nomEtudiantASuprimmer}'";

                SqlCommand command = new(request, connection);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} lignes affectées");
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }

        }
        public Etudiant(string nom, string prenom, int classNb, string dateDiplome)
        {
            _nom = nom;
            _prenom = prenom;
            _classNb = classNb;
            _dateDiplome = dateDiplome;
         //
         //Etudiant.MesEtudiants.Add(this);
        }        
        public Etudiant(int id, string nom, string prenom, int classNb, string dateDiplome) : this(nom, prenom, classNb, dateDiplome)
        {
            _id = id;
         //
         //Etudiant.MesEtudiants.Add(this);
        }


    }
}
