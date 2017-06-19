using System;
using System.Web.Mvc;
using System.Web.Security;

namespace ElearningM1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignIn()
        {
            return Redirect("~/Logon.aspx");
        }


        public ActionResult SignOut(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Remove("typeUtilisateur");
            return Redirect("~/Logon.aspx");
        }
    }
}