using ElearningM1.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningM1.Models
{
    static class BDD
    {
        private static NpgsqlConnection conn;


        // Ici on initialise de la base de donnée avec la methode Initialize

        public static void Initialize()
        {
            conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=wassim;Database=postgres;port=5432");
            
        }

        public static NpgsqlConnection Connexion()
        {
            return conn;
        }

        public static void Open()
        {
            conn.Open();
        }

        public static void Close()
        {
            conn.Close();
        }
    }
}