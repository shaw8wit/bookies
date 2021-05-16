using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Books()
        {
            return View("Book");
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Reach out to us!";

            return View();
        }
    }
}