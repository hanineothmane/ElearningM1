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

        public ActionResult GetAllTuteurEnseigant()
        {
            
            string select = "SELECT * FROM \"Utilisateur\"";
          
            List<TuteurEnseignant> te = Connexion(select).AsEnumerable().Select(row =>

                new TuteurEnseignant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<string>("courriel"), row.Field<int>("id"), row.Field<string>("mdp"), row.Field<string>("telephone"), row.Field<string>("adresse"))              {
                    
                    Nom = row.Field<string>("nom"),
                    DateNaiss = row.Field<string>("datenaissance"),
                    Prenom = row.Field<string>("prenom"),
                    Courriel = row.Field<string>("courriel"),
                    Id = row.Field<int>("id"),
                    Mdp = row.Field<string>("mdp"),
                    Telephone = row.Field<string>("telephone"),

                }

            ).ToList();
            te.Cast<TuteurEnseignant>();
            
            return View(te) ;

        }

        public ActionResult InfoTe(int id)
        {
            
            string select = "SELECT * FROM \"Utilisateur\" WHERE id =" +id ;

            


            List<TuteurEnseignant> te = Connexion(select).AsEnumerable().Select(row =>

                new TuteurEnseignant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<string>("courriel"), row.Field<int>("id"), row.Field<string>("mdp"), row.Field<string>("telephone"), row.Field<string>("adresse"))
                {
                    Id = row.Field<int>("id"),
                    Nom = row.Field<String>("nom"),
                    Prenom = row.Field<String>("prenom"),
                    DateNaiss = row.Field<String>("datenaissance"),
                    Courriel = row.Field<String>("courriel"),
                    Mdp = row.Field<String>("mdp"),
                    Telephone = row.Field<String>("telephone"),
                    Adresse = row.Field<String>("adresse")

                }

            ).ToList();
            te.Cast<TuteurEnseignant>();

            

            return View(te);
            
        }


        public ActionResult consulterInfoApprenants(int id)
        {

            string select = "SELECT * FROM \"Apprenant\" WHERE id ="+id ;

            List<Apprenant> te = Connexion(select).AsEnumerable().Select(row =>

                new Apprenant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"),null, row.Field<int>("id"), null, row.Field<string>("telephone"), row.Field<string>("adresse"),null)

       
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