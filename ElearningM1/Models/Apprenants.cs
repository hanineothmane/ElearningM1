using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElearningM1.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Web.Mvc;

namespace ElearningM1.Models
{
    public class Apprenants
    {
        public List<Apprenant> getApprenants()
        {
            BDD.Initialize();

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            BDD.Open();
            string select = "SELECT * FROM \"Utilisateur\"";
            NpgsqlCommand MyCmd = new NpgsqlCommand(select, BDD.Connexion());
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            BDD.Close();



            List<Apprenant> module = MyData.AsEnumerable().Select(row =>

                new Apprenant(row.Field<string>("nom"), row.Field<string>("dateNaiss"), row.Field<string>("prenom"), row.Field<string>("courriel"), row.Field<string>("id"), row.Field<string>("mdp"), row.Field<string>("telephone"),null)
                {

                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("dateNaiss"),
                    Courriel = row.Field<string>("courriel"),
                    Telephone = row.Field<string>("telephone"),


                }

            ).ToList();
            module.Cast<Apprenant>();



            return module;
        }
    }
}