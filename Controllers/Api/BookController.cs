using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
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
            return Ok(
                _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .ToList()
                .Select(Mapper.Map<Book, BookDto>)
            );
        }

        // GET /api/book/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .SingleOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();
            var bookDto = Mapper.Map<Book, BookDto>(book);
            return Ok(bookDto);
        }

        // POST /api/book
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var book = Mapper.Map<BookDto, Book>(bookDto);
            List<Author> authors = new List<Author>();
            foreach(AuthorDto authorDto in bookDto.Authors)
            {
                Author author = _context.Authors.SingleOrDefault(a => a.Id == authorDto.Id);
                if (author == null) return BadRequest();
                authors.Add(author);
            }
            book.Authors = authors;
            List<Genre> genres = new List<Genre>();
            foreach (GenreDto genreDto in bookDto.Genres)
            {
                Genre genre = _context.Genres.SingleOrDefault(a => a.Id == genreDto.Id);
                if (genre == null) return BadRequest();
                genres.Add(genre);
            }
            book.Genres = genres;
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
