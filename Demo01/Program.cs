using Azure.Core;
using Microsoft.Data.SqlClient;
using System.Data;

// connectionString
string connectionString = "Data Source=(localdb)\\exerciceDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; Database = contactDB";

// Création d'un objet SQLConnection présent dans la libraire ADO.NET
SqlConnection connection = new SqlConnection(connectionString);

connection.Open();

if (connection.State == ConnectionState.Open)
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

// Libère la commande SQL
command.Dispose();

// Ferme la connexion 
connection.Close();

//using (SqlConnection conn = new SqlConnection(connectionString))
//{


//    string request = "INSERT INTO personnes (prenom, nom, email) VALUES (@prenom, @nom, @email)";

//    SqlCommand command = new SqlCommand(request, conn);
//    // Syntaxe simplifiée
//    command.Parameters.AddWithValue("@prenom", "léa");

//    // Syntaxe avec la précision du type
//    command.Parameters.Add("@nom", SqlDbType.VarChar);
//    command.Parameters["@nom"].Value = "dupont";

//    command.Parameters.AddWithValue(@"email", "lea@dupont.fr");

//    try
//    {
//        conn.Open();
//        int rowsAffected = command.ExecuteNonQuery();
//        Console.WriteLine($"{rowsAffected} lignes affectées");
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }

//}

//using (SqlConnection conn = new SqlConnection(connectionString))
//{
//    string req = "SELECT * FROM personnes WHERE id=@id";
//    int id = 1;
//    SqlCommand command = new SqlCommand(req, conn);
//    command.Parameters.AddWithValue("@id", id);

//    try
//    {
//        conn.Open();
//        SqlDataReader reader = command.ExecuteReader();

//        while (reader.Read())
//        {
//            Console.WriteLine($" id: {reader.GetInt32(0)}, prenom: {reader.GetString(1)}, nom: , numero_de_classe: {reader.GetInt32(2)}, mail: {reader.GetString(3)}");
//        }
//    } catch(Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
//}


//using (SqlConnection conn = new SqlConnection(connectionString))
//{
//    string req = "SELECT AVG(LEN(prenom)) FROM personnes;";

//    SqlCommand command = new SqlCommand(req, conn);


//    try
//    {
//        conn.Open();

//        // Lorsque la requête ne renvoie qu'un unique résultat, pon utilise execute scalar
//        int averageFirstNameLength = (int) command.ExecuteScalar();

//        Console.WriteLine($"La taille moyenne des prénoms de la table personnes est de {averageFirstNameLength}");

//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }
