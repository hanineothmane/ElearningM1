using ElearningM1.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningM1.Controllers
{
    public class ApprenantController : Controller
    {
       


        public ActionResult GetAllApprenant()
        {
            string select = "SELECT * FROM \"Apprenant\"";

            List<Apprenant> te = Connexion(select).AsEnumerable().Select(row =>
               
               new Apprenant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"),  null,row.Field<int>("id"), null, row.Field<string>("telephone"), row.Field<string>("adresse"),null)
                   {
                       Id = row.Field<int>("id"),
                       Nom = row.Field<String>("nom"),
                       Prenom = row.Field<String>("prenom"),
                       DateNaiss = row.Field<String>("datenaissance"),
                       Telephone = row.Field<String>("telephone"),
                       Adresse = row.Field<String>("adresse")

                   }

            ).ToList();
            te.Cast<Apprenant>();
            return View(te);
        }

        public DataTable Connexion(String requette)
        {

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearning;port=5433");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();

            NpgsqlCommand MyCmd = new NpgsqlCommand(requette, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();

            return MyData;
        }

    }
}