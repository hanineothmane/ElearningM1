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
        
        // utiliser les fichiers pour log les erreurs. 
        //flash 
        //DAL pour la base de données 




        // GET: TuteurEnseignant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InfoTe(int id)
        {
            try
            {
                TuteurEnseignant te = TuteursEnseignant.getInfoTE(id).FirstOrDefault(a => a.Id == id); //Utiliser variable session id
                return View(te);
            }
            catch (NpgsqlException)
            {
                ViewBag.MessageErreur = "Une erreur a été détectée. Veuillez contacter votre administrateur.";
                return View();
            }
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
    }
}