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
using System.Web.Security;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace ElearningM1.BD
{
    public static class Utilisateurs
    {

        private static NpgsqlConnection conn;

        public static void Initialize()
        {
            // conn = new NpgsqlConnection("Server=localhost:5432;User Id=postgres;Password=root;Database=Elearning;");
            // conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=wassim;Database=elearningM1;port=5432");
            conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["elearningM1"].ConnectionString);
        }

    }
}