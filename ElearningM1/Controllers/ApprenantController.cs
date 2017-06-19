using ElearningM1.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElearningM1.BD;

namespace ElearningM1.Controllers
{
    public class ApprenantController : Controller
    {
       
        public ActionResult GetAllApprenant()
        {
            string select = "SELECT * FROM \"Utilisateur\" WHERE type = 'a'";

            List<Apprenant> te = Connexion(select).AsEnumerable().Select(row =>

               new Apprenant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<string>("email"), row.Field<int>("id"), row.Field<string>("telephone"), row.Field<string>("dateinscription"), row.Field<string>("adresse"))
                    {
                        Id = row.Field<int>("id"),
                        Nom = row.Field<String>("nom"),
                        Prenom = row.Field<String>("prenom"),
                        DateNaiss = row.Field<String>("datenaissance"),
                        Email = row.Field<String>("email"),
                        Telephone = row.Field<String>("telephone"),
                        Adresse = row.Field<String>("adresse"),
                        DateInscription = row.Field<String>("dateinscription"),
                    }

            ).ToList();
            te.Cast<Apprenant>();
            return View(te);
        }

        public DataTable Connexion(String requette)
        {

            BDD.Initialize();

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            BDD.Open();

            NpgsqlCommand MyCmd = new NpgsqlCommand(requette, BDD.Connexion());
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            BDD.Close();

            return MyData;
        }

    }
}