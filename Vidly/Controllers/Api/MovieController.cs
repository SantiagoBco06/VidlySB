using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movie
        [HttpGet]
        public IEnumerable<MovieDto> GetMovie()
        {
            return _context.Movies
                .Include(m => m.GenreType)
                .ToList().Select( Mapper.Map<Movie, MovieDto> );
        }

        // GET /api/movie/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            
            return Ok( Mapper.Map<Movie, MovieDto>(movie) );
        }

        // POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie( MovieDto movieDto )
        {
            if ( !ModelState.IsValid )
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>( movieDto );
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created( new Uri( Request.RequestUri +  "/" + movie.Id ), movie );
        }

        // PUT /api/movie/1
        [HttpPut]
        public IHttpActionResult UpdateMovie( int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault( m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok( Mapper.Map<Movie,MovieDto>(movieInDb) );
        }

        // DELETE /api/movie/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault( m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            
            return Ok();
        }
    }
}
