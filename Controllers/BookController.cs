using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using bookies.Models;
using bookies.ViewModel;
using System;

namespace bookies.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private ApplicationUserManager _userManager;

        public BookController() { }
        public BookController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // All books list page
        public ActionResult All()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return View(new BookControllerAllViewModel() 
                { 
                    HasLib = user != null && user.LibraryCard != 0, 
                    Books = _context.Books.ToList() 
                }
            );
        }

        // Single book details page
        public ActionResult Details(int? id)
        {
            Book book = _context.Books.Include(b => b.Genres)
                .Include(b => b.Authors).SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // Buy book
        public ActionResult Buy(int id, bool rent)
        {
            if(!Request.IsAuthenticated)
            {
                return RedirectToRoute(new { action = "Login", controller = "Account", area = "" });
            }
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.message = rent ? "Rent" : "Buy";
            return View("Pay", book);
        }

        /*
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
        */

        //sell books
        [HttpGet]
        public ActionResult Addforsale()
        {
            Book book = new Book();
            return View(book);
        }

        [HttpPost]
        public ActionResult Addforsale(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("book", "book");
        }

        public ActionResult Pay(int id, bool rent)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToRoute(new { action = "Login", controller = "Account", area = "" });
            }
            var userId = User.Identity.GetUserId();
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            var book = _context.Books.Include(b => b.Authors).Include(b => b.Genres).SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            DateTime curDate = DateTime.Today;
            if(rent)
            {
                DateTime dueDate = curDate.AddDays(7);
                Rent rentData = new Rent()
                {
                    RentDate = curDate,
                    DueDate = dueDate,
                    Book = book,
                    User = user
                };
                _context.Rents.Add(rentData);
                _context.SaveChanges();
            }
            Sale saleData = new Sale()
            {
                Date = curDate,
                SaleType = Convert.ToByte(rent),
                Book = book,
                User = user,
                Amount = book.Price / (rent ? 5 : 1)
            };
            _context.Sales.Add(saleData);
            _context.SaveChanges();
            return RedirectToAction("All");
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

