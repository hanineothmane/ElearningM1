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
    [Authorize]
    public class RPController : Controller
    {

        private RespPedagogique rp = (RespPedagogique)(System.Web.HttpContext.Current.Session["utilisateur"]);


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
                    rp.AjouterModule(m, id_te, id_sr);
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
            if (ModelState.IsValid)
            {
                try
                {
                    rp.ModifierModule(id, m, id_te, id_sr);
                }
                    catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View(Modules.getModules().SingleOrDefault(mo => mo.Id == id));
                }
            }
            return View("ListeModules");
        }

        public ActionResult SupprimerModule(int id, Module m)
        {
            rp.SupprimerModule(id, m);
            return View("ListeModules");
        }

        public ActionResult getApprenantsModule(int id)
        {
            ViewBag.Module = Modules.getModules().Single(m => m.Id == id);
            return View(rp.LesApprenantsParModule(id));
        }
        #endregion

        #region Apprenant


        [HttpGet]
        public ActionResult InsererApprenant()
        {
            var apprenant = new Apprenant();
            return View(apprenant);
        }

        [HttpPost]
        public ActionResult InsererApprenant(Apprenant a)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    rp.AjouterApprenant(a);
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View();
                }
            }
            return RedirectToAction("ListeApprenants", "Commun");
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
            if (ModelState.IsValid)
            {
                try
                {
                    rp.ModifierApprenant(id, a);
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View(Apprenants.getApprenants().SingleOrDefault(app => app.Id == id));
                }
            }
            return RedirectToAction("ListeApprenants", "Commun");
        }

        public ActionResult getModulesApprenant(int id)
        {
            ViewBag.Apprenant = Apprenants.getApprenants().Single(ap => ap.Id == id);
            return View(rp.LesModulesParApprenant(id));
        }

        public ActionResult SupprimerApprenant(int id, Apprenant a)
        {
            rp.SupprimerApprenant(id, a);
            return RedirectToAction("ListeApprenants", "Commun");
        }
        #endregion

        #region Profil
            
        public ActionResult ListeTuteursEnseignant()
        {
            return View(TuteursEnseignant.getTuteursEnseignant());
        }

        public ActionResult ListeRP()
        {
            return View(RespPedagogiques.getRPs());
        }

        [HttpGet]
        public ActionResult InsererProfil()
        {
            var p = new Profil();
            return View(p);
        }

        [HttpPost]
        public ActionResult InsererProfil(string type, Profil profil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (type == "TE")
                    {
                        rp.AjouterProfil(type, profil);
                        return Redirect("ListeTuteursEnseignant");
                    }

                    if (type == "RP")
                    {
                        rp.AjouterProfil(type, profil);
                        return Redirect("ListeRP");
                    }
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
        public ActionResult ModifierProfil(string type, int id)
        {
            
            if (type == "TE")
            {
                ViewBag.Type = "Tuteur enseignant";
                var te = TuteursEnseignant.getTuteursEnseignant().SingleOrDefault(t => t.Id == id);
                return View(te);
            }

            if (type == "RP")
            {
                ViewBag.Type = "Responsable pédagogique";
                var rp = RespPedagogiques.getRPs().SingleOrDefault(t => t.Id == id);
                return View(rp);
            }
            
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult ModifierProfil(string type, int id, Profil profil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(type == "TE")
                    {
                        rp.ModifierProfil(type, id, profil);
                        return View("ListeTuteursEnseignant");
                    }

                    if (type == "RP")
                    {
                        rp.ModifierProfil(type, id, profil);
                        return View("ListeRP");
                    }
                    
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View(Profils.getProfils().Single(p => p.Id == id));
                }
            }
            return View("ListeTuteursEnseignant");
        }

        public ActionResult SupprimerProfil(string type, int id, Profil profil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    rp.SupprimerProfil(type, id, profil);
                    if (type == "TE")
                    {
                        return View("ListeTuteursEnseignant");
                    }

                    if (type == "RP")
                    {
                        return View("ListeRP");
                    }
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View("Error");
                }
            }
            return View("Error");
        }
        #endregion

        #region Examen
        [HttpGet]
        public ActionResult InsererExamen()
        {
            var examen = new Examen();
            return View(examen);
        }

        [HttpPost]
        public ActionResult InsererExamen(Examen examen, int id_module)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    rp.AjouterExamen(examen, id_module);
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View(new Examen());
                }
            }
            return Redirect("ListeExamens");
        }

        //Commun
        public ActionResult ListeExamens()
        {
            return View(Examens.getExamens());
        }

        public ActionResult SupprimerExamen(int id,Examen examen)
        {
            rp.SupprimerExamen(id, examen);
            return View("ListeExamens");
        }

        public ActionResult getExamensModule(int id)
        {
            ViewBag.Module = Modules.getModules().Single(m => m.Id == id);
            return View(rp.LesExamensParModule(id));
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
                    rp.AjouterNote(aff, id_app, id_module);
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View();
                }
            }
            return Redirect("getModulesApprenant/" + id_app);
        }

        #endregion

        #region Affectation Module Apprenant

        [HttpGet]
        public ActionResult Affecter_A_Module()
        {
            var list_principale = new A_TE_Module_View();
            list_principale.Apprenant = Apprenants.getApprenants();
            list_principale.Module = Modules.getModules();
            return View(list_principale);
        }

        [HttpPost]
        public ActionResult Affecter_A_Module(int id_module, int id_A)
        {
            try
            {
                rp.AffecterApprenantModule(id_module, id_A);
                ViewBag.Message = "Affectation réalisée avec succès !";
            }
            catch (NpgsqlException)
            {
                ViewBag.Message = "Erreur lors de l'affectation !";
                return View();
            }
            return View();
        }

        #endregion

        #region Affectation Tuteur Apprenant

        [HttpGet]
        public ActionResult Affecter_A_Te()
        {
            var list_principale = new A_TE_Module_View();
            list_principale.Te = TuteursEnseignant.getTuteursEnseignant();
            list_principale.Apprenant = Apprenants.getApprenants();
            list_principale.Module = Modules.getModules();
            return View(list_principale);
        }

        [HttpPost]
        public ActionResult Affecter_A_Te(int id_app, int id_tuteur)
        {
            try
            {
                rp.AffecterApprenantExamen(id_app, id_tuteur);
                ViewBag.Message = "Affectation réalisée avec succès !";
            }
            catch (NpgsqlException)
            {
                ViewBag.Message = "Erreur lors de l'affectation !";
                return View();
            }
            return View();
        }

        #endregion

        #region Affectation Module à Semestre

        [HttpGet]
        public ActionResult Affecter_Module_Semestre()
        {
            var list_principal = new A_TE_Module_View();
            // si la liste semestre et vide ou module et vide on le redirige vers la page saisir un module ou un semestre
            list_principal.Semestre = Semestres.getAllSemestre();
            list_principal.Module = Modules.getModules();
            return View(list_principal);
        }

        [HttpPost]
        public ActionResult Affecter_Module_Semestre(int id_semestre, int id_module)
        {
            try
            {
                rp.AffecterModuleSemestre(id_semestre, id_module);
                ViewBag.Message = "Affectation réalisée avec succès !";
            }
            catch (NpgsqlException)
            {
                ViewBag.Message = "Erreur lors de l'affectation !";
                return Redirect("Error");
            }
            return View();
        }

        #endregion

        #region Affectation Examen à Module

        [HttpGet]
        public ActionResult Affecter_A_Examen()
        {
            var list_principal = new A_TE_Module_View();
            list_principal.Apprenant = Apprenants.getApprenants();
            list_principal.Examen = Examens.getExamens();
            return View(list_principal);
        }

        [HttpPost]
        public ActionResult Affecter_A_Examen(string id_A, string id_Exam)
        {
            try
            {
                rp.AffecterApprenantExamen(Int32.Parse(id_A), Int32.Parse(id_Exam));
                ViewBag.Message = "Affectation réalisée avec succès !";
            }
            catch (NpgsqlException)
            {
                ViewBag.Message = "Erreur lors de l'affectation !";
                var list_principal = new A_TE_Module_View();
                list_principal.Apprenant = Apprenants.getApprenants();
                list_principal.Examen = Examens.getExamens();
                return View(list_principal);
            }
            return Redirect("ListeExamens");
        }

        #endregion

        #region Session de regroupement

        public ActionResult ListeSessionsRegroupement()
        {
            return View(SessionsRegroupement.getSessionsRegroupement());
        }

        [HttpGet]
        public ActionResult InsererSessionReg()
        {
            var sessionReg = new SessionRegroupement();
            return View(sessionReg);
        }

        [HttpPost]
        public ActionResult InsererSessionReg(SessionRegroupement sr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    rp.AjouterSessionReg(sr);
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View();
                }
            }
            return Redirect("ListeSessionsRegroupement");
        }

        [HttpGet]
        public ActionResult ModifierSessionReg(int id)
        {
            var sr = SessionsRegroupement.getSessionsRegroupement().SingleOrDefault(s => s.Id == id);
            if (sr == null)
                return HttpNotFound();
            return View(sr);
        }

        [HttpPost]
        public ActionResult ModifierSessionReg(int id, SessionRegroupement sr)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    rp.ModifierSessionReg(id, sr);
                }
                catch (NpgsqlException)
                {
                    ViewBag.MessageErreur = "Erreur lors de l'affectation !";
                    return View(SessionsRegroupement.getSessionsRegroupement().SingleOrDefault(s => s.Id == id));
                }
            }
            return View("ListeSessionsRegroupement");
        }

        public ActionResult SupprimerSessionReg(int id, SessionRegroupement sr)
        {
            rp.SupprimerSessionReg(id, sr);
            return View("ListeSessionsRegroupement");
        }
        #endregion
    }
}