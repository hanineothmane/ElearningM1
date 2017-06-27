using ElearningM1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningM1.Controllers
{
    public class CommunController : Controller
    {
        // GET: Commun
        public ActionResult Index()
        {
            return View();
        }

        //Commun
        public ActionResult ListeApprenants()
        {
            var apprenants = Apprenants.getApprenants();
            return View(apprenants);
        }
    }
}