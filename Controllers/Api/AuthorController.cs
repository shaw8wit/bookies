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
        public IEnumerable<AuthorDto> GetAuthors()
        {
            return _context.Authors.ToList().Select(Mapper.Map<Author, AuthorDto>);
        }

        // POST /api/author
        [HttpPost]
        public AuthorDto CreateAuthor(AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var author = Mapper.Map<AuthorDto, Author>(authorDto);
            _context.Authors.Add(author);
            _context.SaveChanges();
            authorDto.Id = author.Id;
            return authorDto;
        }

        //PUT /api/author/1
        [HttpPut]
        public void UpdateAuthor(int id, AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var authorInDb = _context.Authors.SingleOrDefault(a => a.Id == id);
            if (authorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(authorDto, authorInDb);
            _context.SaveChanges();
        }

        // DELETE /api/author/1
        [HttpDelete]
        public void DeleteAuthor(int id)
        {
            var authorInDb = _context.Authors.SingleOrDefault(a => a.Id == id);
            if (authorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Authors.Remove(authorInDb);
            _context.SaveChanges();
        }
    }
}
