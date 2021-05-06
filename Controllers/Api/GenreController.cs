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
        public IHttpActionResult GetAllGenre()
        {
            return Ok(_context.Genres.ToList().Select(Mapper.Map<Genre, GenreDto>));
        }

        // GET /api/genre/1
        public IHttpActionResult GetGenre(int id)
        {
            var genre = _context.Genres.SingleOrDefault(g => g.Id == id);
            if (genre == null)
                return NotFound();
            return Ok(Mapper.Map<Genre, GenreDto>(genre));
        }

        // POST /api/genre
        [HttpPost]
        public IHttpActionResult CreateGenre(GenreDto genreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var genre = Mapper.Map<GenreDto, Genre>(genreDto);
            _context.Genres.Add(genre);
            _context.SaveChanges();
            genreDto.Id = genre.Id;
            return Created(new Uri(Request.RequestUri + "/" + genre.Id), genreDto);
        }

        //PUT /api/author/1
        [HttpPut]
        public IHttpActionResult UpdateGenre(int id, GenreDto genreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);
            if (genreInDb == null)
                return NotFound();
            Mapper.Map(genreDto, genreInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE /api/genre/1
        [HttpDelete]
        public IHttpActionResult DeleteGenre(int id)
        {
            var genreInDb = _context.Genres.SingleOrDefault(g => g.Id == id);
            if (genreInDb == null)
                return NotFound();
            _context.Genres.Remove(genreInDb);
            _context.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}