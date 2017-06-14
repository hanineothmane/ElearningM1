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
    public static class Apprenants
    {
        public static List<Apprenant>  getApprenants()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();
            string select = "SELECT * FROM \"Apprenant\"";
            NpgsqlCommand MyCmd = new NpgsqlCommand(select, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();



            List<Apprenant> apprenant = MyData.AsEnumerable().Select(row =>

                new Apprenant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<int>("id_apprenant"), row.Field<string>("telephone"), row.Field<string>("adresse"),null)
                {
                    Id = row.Field<int>("id_apprenant"),
                    Nom = row.Field<string>("nom"),
                    Prenom = row.Field<string>("prenom"),
                    DateNaiss = row.Field<string>("datenaissance"),
                    Telephone = row.Field<string>("telephone"),
                    Adresse = row.Field<string>("adresse")

                }

            ).ToList();
            apprenant.Cast<Apprenant>();



            return apprenant;
        }
    }
}