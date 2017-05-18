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
    public static class Apprenants
    {
        public static List<Apprenant> getApprenants()
        {
            
            string select = "SELECT * FROM \"Utilisateur\" WHERE type='apprenant' ORDER BY nom";
            
            List<Apprenant> apprenant = BDD.Execute(select).AsEnumerable().Select(row =>

                new Apprenant(row.Field<string>("nom"), row.Field<string>("dateNaiss"), row.Field<string>("prenom"), row.Field<string>("courriel"), row.Field<int>("id"), row.Field<string>("mdp"), row.Field<string>("telephone"), null, row.Field<string>("adresse"))
                {

                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("dateNaiss"),
                    Courriel = row.Field<string>("courriel"),
                    Telephone = row.Field<string>("telephone"),
                    Adresse = row.Field<string>("adresse"),

                }

            ).ToList();
            apprenant.Cast<Apprenant>();
            
            return apprenant;
        }

        public static void AddApprenant(Apprenant a)
        {
            string select = "INSERT INTO \"Utilisateur\" VALUES ('" + a.Nom + "','" + a.DateNaiss + "','" + a.Prenom + "','" + a.Courriel + "','" + a.Mdp + "', '" + a.Telephone + "', '', 'apprenant', '')";
            BDD.ExecuteNonQuery(select);
        }

        public static void Update(Apprenant a)
        {
            string select = "UPDATE \"Utilisateur\" SET nom='" + a.Nom + "', datenaiss='" + a.DateNaiss + "', prenom='" + a.Prenom + "', courriel='" + a.Courriel + "', mdp='" + a.Mdp + "', telephone='" + a.Telephone + "' WHERE id=" + a.Id + "";
            BDD.ExecuteNonQuery(select);
        }
    }
}