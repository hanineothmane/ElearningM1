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
    public static class TuteursEnseignant
    {
        public static List<TuteurEnseignant> getTuteursEnseignant()
        {
            
            string select = "SELECT * FROM \"TE\" ORDER BY nom";
            
            List<TuteurEnseignant> te = BDD.Execute(select).AsEnumerable().Select(row =>

                new TuteurEnseignant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<string>("email"), row.Field<int>("id_te"), row.Field<string>("mdp"), row.Field<string>("telephone"), row.Field<string>("adresse"))
                {
                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("datenaissance"),
                    Id = row.Field<int>("id_te"),
                    Email = row.Field<string>("email"),
                    Adresse = row.Field<string>("adresse"),
                    Mdp = row.Field<string>("mdp"),
                    Telephone = row.Field<string>("telephone"),
                }

            ).ToList();
            te.Cast<TuteurEnseignant>();



            return te;
        }

        public static void AddTE(TuteurEnseignant te)
        {
            //string select = "INSERT INTO \"Utilisateur\" VALUES ('" + a.Nom + "','" + a.DateNaiss + "','" + a.Prenom + "','" + a.Email + "','" + a.DateInscription + "', '" + a.Telephone + "', '', 'apprenant', '')";
            string select = "SELECT inserer_te('" + te.Nom + "','" + te.Prenom + "', '" + te.Adresse + "', '" + te.Telephone + "', '" + te.DateNaiss + "' ,'" + te.Email + "', '" + te.Mdp + "' )";
            BDD.ExecuteNonQuery(select);
        }

        public static void Update(TuteurEnseignant te)
        {
            string select = "SELECT modifier_te('" + te.Id + "','" + te.Nom + "','" + te.Prenom + "', '" + te.Adresse + "', '" + te.Telephone + "', '" + te.DateNaiss + "' ,'" + te.Email + "', '" + te.Mdp + "' )";
            BDD.ExecuteNonQuery(select);
        }
    }
}