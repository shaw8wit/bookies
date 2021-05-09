using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using bookies.Models;

namespace bookies.Controllers.Api
{
    public class SalesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Sales
        public IHttpActionResult GetSales()
        {
            return Ok(db.Sales.Include(s => s.User).Include(s => s.Book).ToList());
        }

        // GET: api/Sales/5
        [ResponseType(typeof(Sale))]
        public IHttpActionResult GetSale(int id)
        {
            Sale sale = db.Sales
                .Include(s => s.User)
                .Include(s => s.Book)
                .SingleOrDefault(s => s.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSale(int id, Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = db.Users.SingleOrDefault(u => u.Id == sale.User.Id);
            Book book = db.Books.SingleOrDefault(b => b.Id == sale.Book.Id);
            if (user == null || book == null || id != sale.Id) return BadRequest();
            sale.User = user;
            sale.Book = book;

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sales
        [ResponseType(typeof(Sale))]
        public IHttpActionResult PostSale(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser user = db.Users.SingleOrDefault(u => u.Id == sale.User.Id);
            Book book = db.Books.SingleOrDefault(b => b.Id == sale.Book.Id);
            if (user == null || book == null) return BadRequest();
            sale.User = user;
            sale.Book = book;

            db.Sales.Add(sale);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sale))]
        public IHttpActionResult DeleteSale(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            db.Sales.Remove(sale);
            db.SaveChanges();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int id)
        {
            return db.Sales.Count(e => e.Id == id) > 0;
        }
    }
}