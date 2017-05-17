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
namespace ElearningM1.BD
{
    public static class BDD
    {
        private static NpgsqlConnection conn;

        public static void Initialize() { 
            // conn = new NpgsqlConnection("Server=localhost:5432;User Id=postgres;Password=root;Database=Elearning;");
            conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=wassim;Database=postgres;port=5432");
        }

        public static NpgsqlConnection Connexion() { 
            return conn;
        }

        public static void Open(){
            conn.Open();
        }    

        public static void Close(){
            conn.Close();
        }             
    }
}