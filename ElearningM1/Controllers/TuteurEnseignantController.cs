using ElearningM1.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningM1.Controllers
{
    public class TuteurEnseignantController : Controller
    {
        

        // GET: TuteurEnseignant
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult AllApprenant()
        {

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=wassim;Database=postgres;port=5432");

            DataTable MyData = new DataTable();
            NpgsqlDataAdapter da;

            conn.Open();
            string select = "SELECT * FROM \"Utilisateur\"";
            NpgsqlCommand MyCmd = new NpgsqlCommand(select, conn);
            da = new NpgsqlDataAdapter(MyCmd);
            da.Fill(MyData);
            conn.Close();



            List<TuteurEnseignant> te = MyData.AsEnumerable().Select(row =>

                new TuteurEnseignant(row.Field<string>("nom"), row.Field<string>("dateNaiss"), row.Field<string>("prenom"), row.Field<string>("courriel"), row.Field<string>("id"), row.Field<string>("mdp"), row.Field<string>("telephone"))              {
                    
                    Nom = row.Field<string>("nom"),
                    DateNaiss = row.Field<string>("dateNaiss"),
                    Prenom = row.Field<string>("prenom"),
                    Courriel = row.Field<string>("courriel"),
                    Id = row.Field<string>("id"),
                    Mdp = row.Field<string>("mdp"),
                    Telephone = row.Field<string>("telephone"),

                }

            ).ToList();
            te.Cast<TuteurEnseignant>();








            //            IList<Class1> items = dt.AsEnumerable().Select(row =>
            //new Class1
            //{
            //    id = row.Field<string>("id"),
            //    name = row.Field<string>("name")
            //}).ToList();

            //var Te = new TuteurEnseignant()
            //{
            //    id = 1,
            //    nom = "Haninos",
            //    prenom = "othmanos",
            //    ListApprenant = new List<Apprenant>()
            //    {
            //        new Apprenant{id = 1, nom = "hanine", prenom = "othmane", dateinscription = "28/10/2017"},
            //        new Apprenant{id = 2,nom = "hanine",prenom = "oussama", dateinscription = "28/11/2017"}
            //    }


            //};
            // on affiche le premier element de la liste de tuteur enseigant te
            //te.First()


            return View(te) ;

        }

        public ActionResult InfoApprenant(int id)
        {
            
            



            return View();


        }
        public void connexionBDD()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearning;port=5433");
            conn.Open();
            // Define a query
            //string insert = "INSERT INTO \"Utilisateur\"(id,courriel,nom,prenom,telephone,adresse,mdp,datenaissance) values(DEFAULT,\'hanine@gmail.com\',\'Hanine\',\'othmane\',\'0663734496\',\'3 rue auguste poullain \',\'root\',\'28/11/1991\')";

            //NpgsqlCommand MyCmd = new NpgsqlCommand(insert, conn);


            //MyCmd.ExecuteNonQuery(); //Exécution
            //conn.Close();

        }
    }
}