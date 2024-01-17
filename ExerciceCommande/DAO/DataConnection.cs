using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciceCommande.DAO
{
    internal class DataConnection
    {
        private static readonly string _connectionString = "Data Source=(localdb)\\exerciceDB02;Initial Catalog=exerciceCommandes;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static SqlConnection GetConnection {  get => new SqlConnection(_connectionString); }
    }
}
