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
using ElearningM1.Models;

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

        public static RespPedagogique ConnexionRP(string mail, string mdp)
        {
            string select = "select * from \"RP\" where email = '" + mail + "' and mdp = '" + mdp + "'";
            if (Execute(select).Rows.Count > 0)
            {
                List<RespPedagogique> Rp =  BDD.Execute(select).AsEnumerable().Select(row =>
                   new RespPedagogique(row.Field<string>("nom"), row.Field<String>("datenaissance"), row.Field<String>("prenom"), row.Field<String>("email"), row.Field<int>("id_rp"), row.Field<String>("mdp"), row.Field<String>("telephone"), row.Field<String>("adresse"))
                   {
                       Id = row.Field<int>("id_rp"),
                       Nom = row.Field<String>("nom") ,
                       Prenom = row.Field<String>("prenom"),
                       DateNaiss = row.Field<String>("datenaissance"),
                       Email = row.Field<String>("email"),
                       Mdp = row.Field<String>("mdp"),
                       Telephone = row.Field<String>("telephone"),
                       Adresse = row.Field<String>("adresse")
                   }
               ).ToList();
                return Rp.First();
                 
            }
            return null;
        }

        public static TuteurEnseignant ConnexionTE(string mail, string mdp)
        {
            string select = "select * from \"TE\" where email = '" + mail + "' and mdp = '" + GenerateMD5(mdp) + "'";
            if (Execute(select).Rows.Count > 0)
            {
                List<TuteurEnseignant> te =  BDD.Execute(select).AsEnumerable().Select(row =>
                new TuteurEnseignant()
                {
                    Id = row.Field<int>("id_te"),
                    Nom = row.Field<String>("nom"),
                    Prenom = row.Field<String>("prenom"),
                    DateNaiss = row.Field<String>("datenaissance"),
                    Email = row.Field<String>("email"),
                    Mdp = GenerateMD5(row.Field<String>("mdp")),
                    Telephone = row.Field<String>("telephone"),
                    Adresse = row.Field<String>("adresse")
                }
            ).ToList();
                return te.First();
            }
            else return null;
        }

        public static Administration ConnexionAdministration(string mail, string mdp)
        {
            string select = "select * from \"Administration\" where email = '" + mail + "' and mdp = '" + GenerateMD5(mdp) + "'";
            if (Execute(select).Rows.Count > 0)
            {
                 List<Administration> admin =  BDD.Execute(select).AsEnumerable().Select(row =>
                new Administration(row.Field<String>("nom"), row.Field<String>("datenaissance"), row.Field<String>("prenom"), row.Field<String>("email"), row.Field<int>("id_admin"), row.Field<String>("mdp"), row.Field<String>("telephone"), row.Field<String>("adresse"))
                {
                    Id = row.Field<int>("id_te"),
                    Nom = row.Field<String>("nom"),
                    Prenom = row.Field<String>("prenom"),
                    DateNaiss = row.Field<String>("datenaissance"),
                    Email = row.Field<String>("email"),
                    Mdp = GenerateMD5( row.Field<String>("mdp")),
                    Telephone = row.Field<String>("telephone"),
                    Adresse = row.Field<String>("adresse")
                }
            ).ToList();
                return admin.First();
            }
            else return null;
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


        

        public static string GenerateMD5(string mdp)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(mdp)).Select(s => s.ToString("x2")));
        }


    }
}