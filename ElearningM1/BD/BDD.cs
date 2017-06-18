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
    public static class BDD
    {
        private static NpgsqlConnection conn;

        public static void Initialize() {
            conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["elearningM1"].ConnectionString);
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

        public static void ExecuteNonQueryPS(string nomPS, Dictionary<string, Object> dic)
        {
            Initialize();
            Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command = Connexion().CreateCommand();
            // On indique que l'on souhaite utiliser une procédure stockée
            command.CommandType = CommandType.StoredProcedure;
            // On donne le nom de cette procédure stockée
            command.CommandText = nomPS;
            // On ajoute les paramèstres liés à la procédure stockée
            foreach (var kv in dic)
            {
                command.Parameters.AddWithValue(kv.Key, kv.Value);
            }
            // On execute la commande
            command.ExecuteNonQuery();
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

        

    }
}