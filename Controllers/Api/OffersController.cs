using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookies.Controllers.Api
{
    public class OffersController : Controller
    {
        // GET: Offers
        public ActionResult OffersView()
        {
            return View();
        }
    }
}