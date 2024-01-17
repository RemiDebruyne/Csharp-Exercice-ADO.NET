using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciceCommande.Classes;
using Microsoft.Data.SqlClient;

namespace ExerciceCommande.DAO
{
    internal class ClientDAO : BaseDAO<Client>
    {

        public override List<Client>? GetAll()
        {
            List<Client> list = new();

            request = "SELECT * FROM clients";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new(request, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {


                    list.Add(new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


        }

        public override Client? GetOneById(int id)
        {
            Client? client = null; ;

            request = "SELECT * FROM clients WHERE id=@id";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new(request, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    CommandeDAO commandeDAO = new();
                    client = new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                    client.Commandes = commandeDAO.GetAllbyClient(client);

                }
                return client;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public override Client Save(Client client)
        {
            request = "INSERT INTO clients (prenom, nom, adresse, cp, ville, telephone) OUTPUT INSERTED.ID VALUES( @prenom, @nom, @adresse, @cp, @ville, @telephone)";

            using SqlConnection connection = DataConnection.GetConnection;

            using SqlCommand command = new(request, connection);

            command.Parameters.AddWithValue("@prenom", client.Prenom);
            command.Parameters.AddWithValue("@nom", client.Nom);
            command.Parameters.AddWithValue("@adresse", client.Adresse);
            command.Parameters.AddWithValue("@cp", client.CodePostal);
            command.Parameters.AddWithValue("@ville", client.Ville);
            command.Parameters.AddWithValue("@telephone", client.Telephone);

            connection.Open();

            client.Id = (int)command.ExecuteScalar();

            client.Commandes.ForEach(commande =>
            {
                CommandeDAO commandeDAO = new CommandeDAO();
                commande.Client = client;
            });

        }

        public override Client Update(Client element)
        {
            throw new NotImplementedException();
        }

        public override Client Delete(Client element)
        {
            throw new NotImplementedException();
        }


        public override Client AddCommande(Client element)
        {
            throw new NotImplementedException();

        }
    }
}
