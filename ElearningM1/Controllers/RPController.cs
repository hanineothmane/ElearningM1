using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElearningM1.Models;

namespace ElearningM1.Controllers
{
    public class RPController : Controller
    {
        // GET: RP
        public ActionResult Index()
        {
            return View();
        }

        //Commun
        public ActionResult ListeModules()
        {
            Modules lesModules = new Modules();
            ViewData["Modules"] = lesModules.getModules();
            return View(lesModules.getModules());
        }

        //Commun
        public ActionResult ChercheModule(string nom)
        {
            ViewData["NomModule"] = nom;
            Modules modules = new Modules();
            Module module = modules.getModules().FirstOrDefault(c => c.Nom == nom);
            if (module != null)
            {
                ViewData["Coeff"] = module.Coeff;
                ViewData["ApprenantsModule"] = module.getApprenants();
                return View("InfosModule");
            }
            return View("Error");
        }

        //Commun
        public ActionResult ListeApprenants()
        {
            Apprenants lesApprenants = new Apprenants();
            ViewData["Apprenants"] = lesApprenants.getApprenants();
            return View(lesApprenants.getApprenants());
        }

        //Commun
        public ActionResult ListeTuteursEnseignant()
        {
            TuteursEnseignant lesTuteursEnseignant = new TuteursEnseignant();
            ViewData["TuteursEnseignant"] = lesTuteursEnseignant.getTuteursEnseignant();
            return View(lesTuteursEnseignant.getTuteursEnseignant());
        }


        //Commun
        public ActionResult ChercheApprenant(string nom)
        {
            ViewData["NomApprenant"] = nom;
            Apprenants apprenants = new Apprenants();
            Apprenant apprenant = apprenants.getApprenants().FirstOrDefault(c => c.Nom == nom);
            if (apprenant != null)
            {
                ViewData["Apprenant"] = apprenant;
                return View("InfosApprenant");
            }
            return View("Error");
        }
        
    }
}