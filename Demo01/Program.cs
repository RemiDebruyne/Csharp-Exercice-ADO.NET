using Azure.Core;
using Microsoft.Data.SqlClient;
using System.Data;

// connectionString
string conncetionString = "Data Source=(localdb)\\exerciceDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; Database = contactDB";

// Création d'un objet SQLConnection présent dans la libraire ADO.NET
SqlConnection connection = new SqlConnection(conncetionString);

connection.Open();

if(connection.State == ConnectionState.Open)
    Console.WriteLine("La connexion est ouverte");
else
    Console.WriteLine("Je suis très triste");

// Requête

string prenom = Console.ReadLine() ?? "";
string nom = Console.ReadLine() ?? "";
string email = Console.ReadLine() ?? "";

string req = $"INSERT INTO personnes (prenom, nom, email) VALUES ('{prenom}','{nom}', '{email}')";

// On instancie un objet de commande qui contient la requete, la connexion ainsi que la transaction si besoin
SqlCommand command = new SqlCommand(req, connection);

// ExecuteNonQuery exécute la requete et renvoie le nombre d'élément affectés
int rowsAffected = command.ExecuteNonQuery();

Console.WriteLine(rowsAffected);

command.Dispose();

connection.Close();