using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElearningM1.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Web.Mvc;
using ElearningM1.BD;

namespace ElearningM1.Models
{
    public class TuteursEnseignant
    {
        public List<TuteurEnseignant> getTuteursEnseignant()
        {
            
            string select = "SELECT * FROM \"Utilisateur\" WHERE type='te' ORDER BY nom";
            
            List<TuteurEnseignant> te = BDD.Execute(select).AsEnumerable().Select(row =>

                new TuteurEnseignant(row.Field<string>("nom"), row.Field<string>("dateNaiss"), row.Field<string>("prenom"), row.Field<string>("courriel"), row.Field<int>("id"), row.Field<string>("mdp"), row.Field<string>("telephone"), row.Field<string>("adresse"))
                {

                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("dateNaiss"),
                    Courriel = row.Field<string>("courriel"),
                    Telephone = row.Field<string>("adresse"),


                }

            ).ToList();
            te.Cast<TuteurEnseignant>();



            return te;
        }
    }
}