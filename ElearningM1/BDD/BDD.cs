using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//On inclue la librairie
using Npgsql;
using NpgsqlTypes;
//Fin

using System.Data;
using System.Text;
namespace ElearningM1.BDD
{
    public class BDD
    {

        public void connexion() { 
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost:5433;User Id=postgres;" +
                               "Password=root;Database=Elearning;");
        conn.Open();
            // Define a query
            NpgsqlCommand cmd = new NpgsqlCommand("insert nom into Utilisateur", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) { 
                Console.Write("{0}\n", dr[0]);

            // Close connection
            conn.Close();
        }
    }
    }
}