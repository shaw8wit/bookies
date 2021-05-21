using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookies.Models;
using Microsoft.AspNet.Identity;

namespace bookies.Controllers
{
    public class LibraryCardController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();

        // Library Card payment page
        public ActionResult LibraryCard()
        {
            return View();
        }

        public ActionResult Pay()
        {
            var userId = User.Identity.GetUserId();
            ApplicationUser user = _context.Users.SingleOrDefault(u => u.Id == userId);
            if(user == null)
            {
                return RedirectToRoute(new { action = "Login", controller = "Account", area = "" });
            }
            user.LibraryCard = 1;
            _context.SaveChanges();
            return RedirectToRoute(new { action = "Index", controller = "Home", area = "" });
        }
    }
}