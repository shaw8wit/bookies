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
    public class BookController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Books
        public ActionResult All()
        {
            return View(_context.Books.ToList());
        }


        //delete book
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Book book = _context.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("Delete",book);
        }


        [HttpPost]
        public ActionResult Delete(string id)
        {
            Book book = _context.Books.Find(Convert.ToInt32(id));
            if (book == null)
            {
                return HttpNotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("book","book");
        }


        //details page
        public ActionResult Details(int? id)
        {
            Book book = _context.Books.Include(b => b.Genres).Include(b => b.Authors).SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("Details", book);
        }
        [HttpPost]
        public ActionResult Details(int id)
        {
            var book1 = _context.Books.Find(id);
            if (book1 == null)
            {
                return HttpNotFound();
            }
            return View(book1);
        }
        public ActionResult Details2(int? id)
        {
            var book1 = _context.Books.Find(id);
            if (book1 == null)
            {
                return HttpNotFound();
            }
            return View("Details2", book1);
        }
        [HttpPost]
        public ActionResult Details2(int id)
        {
            var book1 = _context.Books.Find(id);
            if (book1 == null)
            {
                return HttpNotFound();
            }
            return View(book1);
        }

        //sell books
        [HttpGet]
        public ActionResult Addforsale()
        {

            Book book1 = new Book();
            return View(book1);
        }
        [HttpPost]
        public ActionResult Addforsale(Book book1)
        {
            _context.Books.Add(book1);
            _context.SaveChanges();
            return RedirectToAction("book", "book");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }





    }
    }

