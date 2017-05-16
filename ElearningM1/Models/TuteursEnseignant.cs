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
    public class TuteursEnseignant
    {
        public List<TuteurEnseignant> getTuteursEnseignant()
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



            List<TuteurEnseignant> te = MyData.AsEnumerable().Select(row =>

                new TuteurEnseignant(row.Field<string>("nom"), row.Field<string>("dateNaiss"), row.Field<string>("prenom"), row.Field<string>("courriel"), row.Field<string>("id"), row.Field<string>("mdp"), row.Field<string>("telephone"))
                {

                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("dateNaiss"),
                    Courriel = row.Field<string>("courriel"),
                    Telephone = row.Field<string>("telephone"),


                }

            ).ToList();
            te.Cast<TuteurEnseignant>();



            return te;
        }
    }
}