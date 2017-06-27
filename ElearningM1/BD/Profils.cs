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
    public static class Profils
    {
        public static List<Profil> getProfils()
        {
            string select = "SELECT * FROM \"TE\", \"RP\", \"Administration\" ORDER BY nom";
            return BDD.Execute(select).AsEnumerable().Select(row =>
                new Profil()
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
        }

    }
}
