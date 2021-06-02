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
                IsAdmin = user != null && user.Admin,
                Books = _context.Books.ToList()
            }
            );
        }

        // Single book details page
        public ActionResult Details(int? id)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            Book book = _context.Books.Include(b => b.Genres)
                .Include(b => b.Authors).SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(new BookControllerDetailsViewModel() { IsAdmin = user.Admin, Book = book });
        }

        // Buy book
        public ActionResult Buy(int id, bool rent)
        {
            if (!Request.IsAuthenticated)
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

        //Add book
        public ActionResult AddBook()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (!user.Admin) return RedirectToAction("All");
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("book", "book");
        }ooks.Add(b

        public ActionResult Delete(int id)
        {
            Book book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("All");
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
            if (rent)
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
            int amount = book.Price;
            if (rent)
            {
                if (user.LibraryCard == 0) amount = book.Price / 5;
                else amount = 0;
            }
            Sale saleData = new Sale()
            {
                Date = curDate,
                SaleType = Convert.ToByte(rent),
                Book = book,
                User = user,
                Amount = amount
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

