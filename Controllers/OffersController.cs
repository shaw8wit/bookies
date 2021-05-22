using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookies.Controllers
{
    public class OffersController : Controller
    {
        // GET: Offer
        public ActionResult OffersView()
        {
            return View();
        }
    }
}