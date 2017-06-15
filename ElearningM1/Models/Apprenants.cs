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
            
            string select = "SELECT * FROM \"Apprenant\" ORDER BY nom";
            
            List<Apprenant> apprenant = BDD.Execute(select).AsEnumerable().Select(row =>

                new Apprenant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<string>("email"), row.Field<int>("id_apprenant"), row.Field<string>("telephone"), row.Field<string>("dateinscription"), row.Field<string>("adresse"))
                {
                    Id = row.Field<int>("id_apprenant"),
                    Nom = row.Field<String>("nom"),
                    Prenom = row.Field<String>("prenom"),
                    DateNaiss = row.Field<String>("datenaissance"),
                    Email = row.Field<String>("email"),
                    Telephone = row.Field<String>("telephone"),
                    Adresse = row.Field<String>("adresse"),
                    DateInscription = row.Field<String>("dateinscription"),
                }

            ).ToList();
            apprenant.Cast<Apprenant>();
            
            return apprenant;
        }

        public static List<Apprenant> getApprenant(int id)
        {
            string select = "SELECT * FROM \"Apprenant\" WHERE id_apprenant =" + id;
            List<Apprenant> app = BDD.Execute(select).AsEnumerable().Select(row =>
                new Apprenant()
                {
                    Id = row.Field<int>("id"),
                    Nom = row.Field<String>("nom"),
                    Prenom = row.Field<String>("prenom"),
                    DateNaiss = row.Field<String>("datenaissance"),
                    Telephone = row.Field<String>("telephone"),
                    Adresse = row.Field<String>("adresse")
                }
            ).ToList();
            app.Cast<Apprenant>();
            return app;
        }

        public static void AddApprenant(Apprenant a)
        {
            //string select = "INSERT INTO \"Utilisateur\" VALUES ('" + a.Nom + "','" + a.DateNaiss + "','" + a.Prenom + "','" + a.Email + "','" + a.DateInscription + "', '" + a.Telephone + "', '', 'apprenant', '')";
            string select = "SELECT inserer_apprenant('" + a.Nom + "','" + a.Prenom + "', '" + a.Adresse + "', '" + a.Telephone + "', '" + a.DateNaiss + "' ,'" + a.Email + "', '" + a.DateInscription + "' )";
            BDD.ExecuteNonQuery(select);
        }

        public static void Update(Apprenant a)
        {
            string select = "SELECT modifier_apprenant('" + a.Id + "','" + a.Nom + "','" + a.Prenom + "', '" + a.Adresse + "', '" + a.Telephone + "', '" + a.DateNaiss + "' ,'" + a.Email + "', '" + a.DateInscription + "' )";
            BDD.ExecuteNonQuery(select);
        }
    }
}