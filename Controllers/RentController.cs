using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookies.Models;


namespace bookies.Controllers
{
    public class RentController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Rent

        public ActionResult Rent(int id)
        {
            Rent rent = _context.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View("Rent", rent);
        }
        [HttpPost]
        public ActionResult Rent(string id)
        {
            Rent rent = _context.Rents.Find(Convert.ToInt32(id));
            if (rent == null)
            {
                return HttpNotFound();
            }
            _context.Rents.Remove(rent);
            _context.SaveChanges();
            return RedirectToAction("book", "book");
        }
    }
}