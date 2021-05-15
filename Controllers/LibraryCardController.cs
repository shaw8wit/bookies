using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookies.Controllers
{
    public class LibraryCardController : Controller
    {
        // GET: Library
        public ActionResult LibraryCard()
        {
            return View();
        }
    }
}