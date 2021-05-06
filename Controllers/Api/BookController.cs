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
        public IEnumerable<AuthorDto> GetAuthors()
        {
            return _context.Authors.ToList().Select(Mapper.Map<Author, AuthorDto>);
        }
    }
}
