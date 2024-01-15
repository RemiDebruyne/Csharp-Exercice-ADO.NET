using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Azure.Core;
using Microsoft.Data.SqlClient;


namespace ExerciceAdo.Classes
{
    internal class Etudiant
    {
        private static int _nBEtudiants;
        private string _nom;
        private string _prenom;
        private int _classNb;
        private DateOnly _dateDiplome;


        public void GetAllStudents(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {


            }
        }

        public Etudiant(string nom, string prenom, int classNb, DateOnly dateDiplome )
        {
            _nom = nom;
            _prenom = prenom;
            _classNb = classNb;
            _dateDiplome = dateDiplome;
        }

    }
}
