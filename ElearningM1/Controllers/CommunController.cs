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