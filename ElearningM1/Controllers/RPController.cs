using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPlateformMIAGE.Models;

namespace MyPlateformMIAGE.Controllers
{
    public class RPController : Controller
    {
        // GET: RP
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListeModules()
        {
            Modules lesModules = new Modules();
            ViewData["Modules"] = lesModules.getModules();
            return View();
        }

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

        public ActionResult ChercheApprenant(string nom)
        {
            ViewData["NomApprenant"] = nom;
            Apprenants apprenants = new Apprenants();
            Apprenant apprenant = apprenants.getApprenants().FirstOrDefault(c => c.Nom == nom);
            if (apprenant != null)
            {
                ViewData["Apprenant"] = apprenant;
                return View("InfosModule");
            }
            return View("Error");
        }
    }
}