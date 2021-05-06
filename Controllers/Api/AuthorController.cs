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
    public class AuthorController : ApiController
    {
        private ApplicationDbContext _context;

        public AuthorController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/author
        public IHttpActionResult GetAuthors()
        {
            return Ok(_context.Authors.ToList().Select(Mapper.Map<Author, AuthorDto>));
        }

        // GET /api/author/1
        public IHttpActionResult GetAuthor(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);
            if (author == null)
                return NotFound();
            return Ok(Mapper.Map<Author, AuthorDto>(author));
        }

        // POST /api/author
        [HttpPost]
        public IHttpActionResult CreateAuthor(AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var author = Mapper.Map<AuthorDto, Author>(authorDto);
            _context.Authors.Add(author);
            _context.SaveChanges();
            authorDto.Id = author.Id;
            return Created(new Uri(Request.RequestUri + "/" + author.Id), authorDto);
        }

        //PUT /api/author/1
        [HttpPut]
        public IHttpActionResult UpdateAuthor(int id, AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var authorInDb = _context.Authors.SingleOrDefault(a => a.Id == id);
            if (authorInDb == null)
                return NotFound();
            Mapper.Map(authorDto, authorInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE /api/author/1
        [HttpDelete]
        public IHttpActionResult DeleteAuthor(int id)
        {
            var authorInDb = _context.Authors.SingleOrDefault(a => a.Id == id);
            if (authorInDb == null)
                return NotFound();
            _context.Authors.Remove(authorInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
