using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElearningM1.Models;
using ElearningM1.BD;

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
            return View(Modules.getModules());
        }

        //Commun
        public ActionResult ChercheModule(string nom)
        {
            ViewData["NomModule"] = nom;
            Module module = Modules.getModules().FirstOrDefault(c => c.Nom == nom);
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
            ViewData["Apprenants"] = Apprenants.getApprenants();
            return View(Apprenants.getApprenants());
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
            Apprenant apprenant = Apprenants.getApprenants().FirstOrDefault(c => c.Nom == nom);
            if (apprenant != null)
            {
                ViewData["Apprenant"] = apprenant;
                return View("InfosApprenant");
            }
            return View("Error");
        }

        [HttpGet]
        public ActionResult InsererModule()
        {
            var module = new Module();
            return View(module);
        }

        [HttpPost]
        public ActionResult InsererModule(Module m)
        {
            Modules.AddModule(m);
            return Redirect("ListeModules");
        }

        [HttpGet]
        public ActionResult ModifierModule(int id)
        {
            var module = Modules.getModules().SingleOrDefault(m => m.Id == id);
            if (module == null)
                return HttpNotFound();
            return View(module);
        }

        [HttpPost]
        public ActionResult ModifierModule(int id, Module m)
        {
            var mod = Modules.getModules().Single(mo => mo.Id == id);

            mod.Id = m.Id;
            mod.Nom = m.Nom;
            mod.Coeff = m.Coeff;
            mod.EstNational = m.EstNational;

            Modules.Update(mod);
            

            return View("ListeModules");
        }

        [HttpGet]
        public ActionResult InsererApprenant()
        {
            var apprenant = new Apprenant(null,null,null,null,0,null,null,null,null);
            return View(apprenant);
        }

        [HttpPost]
        public ActionResult InsererApprenant(Apprenant a)
        {
            Apprenants.AddApprenant(a);
            return Redirect("ListeApprenants");
        }

        [HttpGet]
        public ActionResult ModifierApprenant(int id)
        {
            var apprenant = Apprenants.getApprenants().SingleOrDefault(a => a.Id == id);
            if (apprenant == null)
                return HttpNotFound();
            return View(apprenant);
        }

        [HttpPost]
        public ActionResult ModifierApprenant(int id, Apprenant a)
        {
            var app = Apprenants.getApprenants().Single(ap => ap.Id == id);

            app.Id = a.Id;
            app.Nom = a.Nom;
            app.Prenom = a.Prenom;
            app.DateNaiss = a.DateNaiss;
            app.Courriel = a.Courriel;
            app.Telephone = a.Telephone;
            app.Adresse = a.Adresse;
            app.Mdp = a.Mdp;

            Apprenants.Update(app);


            return View("ListeApprenants");
        }
    }
}