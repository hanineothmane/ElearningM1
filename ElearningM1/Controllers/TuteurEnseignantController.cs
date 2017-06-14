using ElearningM1.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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

                new Apprenant(row.Field<string>("nom"), row.Field<string>("datenaissance"), row.Field<string>("prenom"), row.Field<int>("id_te"),row.Field<string>("telephone"), row.Field<string>("dateinscription"), row.Field<string>("adresse"))
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


        public ActionResult Affecter_A_Te()
        {

            var list_principale = new A_TE_Module_View();
            

            list_principale.Te = TuteursEnseignant.getTuteursEnseignant();
            
            list_principale.Apprenant = Apprenants.getApprenants();
            
            list_principale.Module = Modules.getModules();
            
            return View(list_principale);
        }

        [HttpPost]
        public ActionResult insert_A_TE(int id_app, int id_tuteur)
        {
           
            try
            {
                RespPedagogiques.Aff_A_Te(id_app, id_tuteur);
                
            }catch(NpgsqlException)
            {
                ViewBag.erreur = "Erreur lors de l'affectation !";
                return Redirect("Affecter_A_Te");
            }
            
            return View();
        }
        

        public ActionResult Affecter_A_Module()
        {

            var list_principale = new A_TE_Module_View();
            

            list_principale.Apprenant = Apprenants.getApprenants();
            
            list_principale.Module = Modules.getModules();

            return View(list_principale);
        }

        [HttpPost]
        public ActionResult insert_A_Module(int id_module, int id_A)
        {
            try
            {

                RespPedagogiques.Aff_A_Module(id_module,id_A);

            }
            catch (NpgsqlException)
            {
                ViewBag.erreur = "Erreur lors de l'affectation !";
                return Redirect("Affecter_A_Module");
            }
            
            return Redirect("");// il faut creer une page de succées ! 

        }

        public ActionResult Affecter_Module_Semestre()
        {

            var list_principal = new A_TE_Module_View();
            // si la liste semestre et vide ou module et vide on le redirige vers la page saisir un module ou un semestre
            list_principal.Semestre = Semestres.getAllSemestre();

            list_principal.Module = Modules.getModules();


            return View(list_principal); 
        }
        
        [HttpPost]
        public ActionResult insert_Module_Semestre(int id_semestre, int id_module)
        {

            try
            {

                RespPedagogiques.Aff_Module_Semestre(id_semestre,id_module);
            }
            catch (NpgsqlException)
            {
                ViewBag.erreur = "Erreur lors de l'affectation !";
                return Redirect("Error");
            }
            
            return View();
        }


        public ActionResult Affecter_A_Examen()
        {

            var list_principal = new A_TE_Module_View();
            // si la liste semestre et vide ou module et vide on le redirige vers la page saisir un module ou un semestre
            list_principal.Apprenant = Apprenants.getApprenants();

            list_principal.Examen = Examens.getAllExamen();


            return View(list_principal);
        }

        [HttpPost]
        public ActionResult insert_A_Examen(int id_A, int id_Exam)
        {

            try
            {
                RespPedagogiques.Aff_A_Exam(id_A, id_Exam);
            }
            catch (NpgsqlException)
            {
                ViewBag.erreur = "Erreur lors de l'affectation !";
                return Redirect("Error");
            }

            return View("Succees");
        }


        public ActionResult getAffectationTe(int id)
        {
            var listApp = new List<Apprenant>();
            try
            {

               listApp =  TuteursEnseignant.getAllApprenant(id);


            }
            catch (NpgsqlException)
            {
                ViewBag.erreur = "Erreur lors de l'affectation !";
                return Redirect("Error");
            }


            return View(listApp);
        }





        public DataTable Connexion(String requette)
        {

            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres;Password=root;Database=elearningM1;port=5433");

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