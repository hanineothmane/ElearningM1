using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElearningM1.Models;
using ElearningM1.BD;
using System.Web.Security;
using Npgsql;

namespace ElearningM1.Controllers
{
    public class RPController : Controller
    {
        // GET: RP
        public ActionResult Index()
        {
            return View();
        }
        
        #region Module

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
                ViewData["Coeff"] = module.Coef;
                ViewData["ApprenantsModule"] = module.getApprenants();
                return View("InfosModule");
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
        public ActionResult InsererModule(Module m, int id_te, int id_sr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TuteurEnseignant te = TuteursEnseignant.getTuteursEnseignant().FirstOrDefault(c => c.Id == id_te);
                    SessionRegroupement sr = SessionsRegroupement.getSessionsRegroupement().FirstOrDefault(c => c.Id == id_sr);
                    m.Ens = te;
                    m.Sr = sr;
                    Modules.AddModule(m);
                    return Redirect("ListeModules");
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View();
                }
            }
            return View();
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
        public ActionResult ModifierModule(int id, Module m, int id_te, int id_sr)
        {
            var mod = Modules.getModules().Single(mo => mo.Id == id);

            TuteurEnseignant te = TuteursEnseignant.getTuteursEnseignant().FirstOrDefault(c => c.Id == id_te);
            SessionRegroupement sr = SessionsRegroupement.getSessionsRegroupement().FirstOrDefault(c => c.Id == id_sr);

            mod.Id = m.Id;
            mod.Nom = m.Nom;
            mod.DateCreation = m.DateCreation;
            mod.Coef = m.Coef;
            mod.TypeModule = m.TypeModule;
            mod.Ens = te;
            mod.Sr = sr;

            Modules.Update(mod);
            

            return View("ListeModules");
        }
        #endregion

        #region Apprenant

        //Commun
        public ActionResult ListeApprenants()
        {
            ViewData["Apprenants"] = Apprenants.getApprenants();
            return View(Apprenants.getApprenants());
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
        public ActionResult InsererApprenant()
        {
            var apprenant = new Apprenant();
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
            app.Email = a.Email;
            app.Telephone = a.Telephone;
            app.Adresse = a.Adresse;
            app.DateInscription = a.DateInscription;

            Apprenants.Update(app);


            return View("ListeApprenants");
        }

        public ActionResult getModulesApprenant(int id)
        {
            var app = Apprenants.getApprenants().Single(a => a.Id == id);

            ViewBag.Apprenant = app;

            return View(Affecter_A_Modules.getAffectations(app));
        }
        #endregion

        #region TE

        //Commun
        public ActionResult ListeTuteursEnseignant()
        {
            ViewData["TuteursEnseignant"] = TuteursEnseignant.getTuteursEnseignant();
            return View(TuteursEnseignant.getTuteursEnseignant());
        }

        [HttpGet]
        public ActionResult InsererTE()
        {
            var te = new TuteurEnseignant();
            return View(te);
        }

        [HttpPost]
        public ActionResult InsererTE(TuteurEnseignant te)
        {
            TuteursEnseignant.AddTE(te);
            return Redirect("ListeTuteursEnseignant");
        }

        [HttpGet]
        public ActionResult ModifierTE(int id)
        {
            var te = TuteursEnseignant.getTuteursEnseignant().SingleOrDefault(t => t.Id == id);
            if (te == null)
                return HttpNotFound();
            return View(te);
        }

        [HttpPost]
        public ActionResult ModifierTE(int id, TuteurEnseignant te)
        {
            var tut = TuteursEnseignant.getTuteursEnseignant().Single(t => t.Id == id);

            tut.Id = te.Id;
            tut.Nom = te.Nom;
            tut.Prenom = te.Prenom;
            tut.DateNaiss = te.DateNaiss;
            tut.Email = te.Email;
            tut.Telephone = te.Telephone;
            tut.Adresse = te.Adresse;
            tut.Mdp = te.Mdp;

            TuteursEnseignant.Update(tut);
            
            return View("ListeTuteursEnseignant");
        }
        #endregion

        #region NoteFinale

        [HttpGet]
        public ActionResult InsererNote(int id_app, int id_module, int? nf)
        {
            Apprenant app = Apprenants.getApprenants().FirstOrDefault(a => a.Id == id_app);
            Module module = Modules.getModules().FirstOrDefault(m => m.Id == id_module);
            var aff = new Affecter_A_Module(app, module, nf);
            return View(aff);
        }

        [HttpPost]
        public ActionResult InsererNote(Affecter_A_Module aff, int id_app, int id_module)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Apprenant app = Apprenants.getApprenants().FirstOrDefault(a => a.Id == id_app);
                    Module mod = Modules.getModules().FirstOrDefault(m => m.Id == id_module);
                    aff.Apprenant = app;
                    aff.Module = mod;
                    Affecter_A_Modules.AddNote(aff);
                    return Redirect("getModulesApprenant/" + app.Id);
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult ModifierNote(int id)
        {
            var module = Modules.getModules().SingleOrDefault(m => m.Id == id);
            if (module == null)
                return HttpNotFound();
            return View(module);
        }

        [HttpPost]
        public ActionResult ModifierNote(int id, Module m, int id_te, int id_sr)
        {
            var mod = Modules.getModules().Single(mo => mo.Id == id);

            TuteurEnseignant te = TuteursEnseignant.getTuteursEnseignant().FirstOrDefault(c => c.Id == id_te);
            SessionRegroupement sr = SessionsRegroupement.getSessionsRegroupement().FirstOrDefault(c => c.Id == id_sr);

            mod.Id = m.Id;
            mod.Nom = m.Nom;
            mod.DateCreation = m.DateCreation;
            mod.Coef = m.Coef;
            mod.TypeModule = m.TypeModule;
            mod.Ens = te;
            mod.Sr = sr;

            Modules.Update(mod);


            return View("ListeModules");
        }

        #endregion



    }
}