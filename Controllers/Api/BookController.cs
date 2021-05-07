using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using bookies.Models;
using bookies.Dtos;
using AutoMapper;

namespace bookies.Controllers.Api
{
    public class BookController : ApiController
    {
        private ApplicationDbContext _context;

        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/book
        public IHttpActionResult GetBooks()
        {
            return Ok(_context.Books.ToList());
        }

        // GET /api/book/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            return Ok(Mapper.Map<Book, BookDto>(book));
        }

        // POST /api/book
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var book = Mapper.Map<BookDto, Book>(bookDto);
            /*
            book.Authors.Clear();
            book.Genres.Clear();
            foreach(AuthorDto authorDto in bookDto.Authors)
            {
                book.Authors.Append(Mapper.Map<AuthorDto, Author>(authorDto));
            }
            foreach (GenreDto genreDto in bookDto.Genres)
            {
                book.Genres.Append(Mapper.Map<GenreDto, Genre>(genreDto));
            }
            */
            _context.Books.Add(book);
            _context.SaveChanges();
            bookDto.Id = book.Id;
            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }

        //PUT /api/book/1
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb == null)
                return NotFound();
            Mapper.Map(bookDto, bookInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE /api/book/1
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);
            if (bookInDb == null)
                return NotFound();
            _context.Books.Remove(bookInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
