using ExerciceCommande.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExerciceCommande.DAO
{

    internal class CommandeDAO : BaseDAO<Commande>
    {
        public override List<Commande> GetAll()
        {
            List<Commande> list = new();

            request = "SELECT * FROM commandes";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Commande commande = new(reader.GetInt32(0), reader.GetDateTime(2), reader.GetDecimal(3));


                    if (!reader.IsDBNull(1))
                    {
                        ClientDAO clientDAO = new();
                        commande.Client = clientDAO.GetOneById(reader.GetInt32(1));

                    }

                    list.Add(commande);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public List<Commande> GetAllbyClient(Client client)
        {
            List<Commande> list = new();

            request = "SELECT * FROM commandes WHERE id_client=@id_client";

            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand(request, connection);

            command.Parameters.AddWithValue("@id_client", client.Id);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Commande commande = new(reader.GetInt32(0), reader.GetDateTime(2), reader.GetDecimal(3));

                    commande.Client = client;
                    list.Add(commande);
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public override Commande? GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public override Commande Save(Commande commande)
        {
            using SqlConnection connection = DataConnection.GetConnection;
            using SqlCommand command = new SqlCommand();

            if(commande.Client != null)
            {
                request = "INSERT INTO commandes (id, date, total) OUTPUT INSERTED.ID VALUES  (@id, @date, @total)";
                command.CommandText = request;
            }
            else
            {
                request = "INSERT INTO commandes (id, client_id, date, total) OUTUT INSERTED.ID VALUES (@id, @client_id, @date, @total)";
                command.CommandText = request;
                command.Parameters.AddWithValue("client_id", commande.Client.Id);
            }

            command.Parameters.AddWithValue("@date", commande.Date);
            command.Parameters.AddWithValue("@total", commande.PrixTotal);

            command.Connection = connection;
            connection.Open();

            try
            {
            commande.Id = (int)command.ExecuteScalar();
            return commande;

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public override Commande Update(Commande element)
        {
            throw new NotImplementedException();
        }
        public override Commande AddCommande(Commande element)
        {
            throw new NotImplementedException();
        }

        public override Commande Delete(Commande element)
        {
            throw new NotImplementedException();
        }
    }



}
