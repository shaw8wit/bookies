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
    public class GenreController : ApiController
    {
        private ApplicationDbContext _context;

        public GenreController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/genre
        public IEnumerable<GenreDto> GetAllGenre()
        {
            return _context.Genres.ToList().Select(Mapper.Map<Genre, GenreDto>);
        }

        // POST /api/genre
        [HttpPost]
        public GenreDto CreateGenre(GenreDto genreDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var genre = Mapper.Map<GenreDto, Genre>(genreDto);
            _context.Genres.Add(genre);
            _context.SaveChanges();
            genreDto.Id = genre.Id;
            return genreDto;
        }

        //PUT /api/author/1
        [HttpPut]
        public void UpdateGenre(int id, GenreDto genreDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);
            if (genreInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(genreDto, genreInDb);
            _context.SaveChanges();
        }

        // DELETE /api/genre/1
        [HttpDelete]
        public void DeleteGenre(int id)
        {
            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);
            if (genreInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Genres.Remove(genreInDb);
            _context.SaveChanges();
        }
    }
}