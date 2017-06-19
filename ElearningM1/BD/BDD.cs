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
using System.Security.Cryptography;

namespace ElearningM1.BD
{
    public static class BDD
    {
        private static NpgsqlConnection conn;

        public static void Initialize()
        {
            // conn = new NpgsqlConnection("Server=localhost:5432;User Id=postgres;Password=root;Database=Elearning;");
            // conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=wassim;Database=elearningM1;port=5432");
            conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["elearningM1"].ConnectionString);
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

        public static DataTable Execute(String requete)
        {

            Initialize();

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            Open();

            NpgsqlCommand MyCmd = new NpgsqlCommand(requete, Connexion());
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            Close();

            return MyData;
        }

        public static void ExecuteNonQuery(String requete)
        {
            Initialize();
            Open();
            NpgsqlCommand MyCmd = new NpgsqlCommand(requete, Connexion());
            MyCmd.ExecuteNonQuery();
            Close();
        }

        public static bool ConnexionRP(string mail, string mdp)
        {
            string select = "select * from \"RP\" where email = '" + mail + "' and mdp = '" + mdp + "'";
            if (Execute(select).Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }

        public static bool ConnexionTE(string mail, string mdp)
        {
            string select = "select * from \"TE\" where email = '" + mail + "' and mdp = '" + mdp + "'";
            if (Execute(select).Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }

        public static bool ConnexionAdministration(string mail, string mdp)
        {
            string select = "select * from \"Administration\" where email = '" + mail + "' and mdp = '" + mdp + "'";
            if (Execute(select).Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }




        public static string GenerateMD5(string yourString)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(yourString)).Select(s => s.ToString("x2")));
        }


    }
}