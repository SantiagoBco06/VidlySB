using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                GenreTypes = _context.GenreTypes.ToList()
            }; 
            return View("MovieForm",viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Movie movie )
        {

            if( !ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    GenreTypes = _context.GenreTypes.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if( movie.Id == 0)
            {
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
            } else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreTypeId = movie.GenreTypeId;
            }
            
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.Include( m => m.GenreType).Single(m => m.Id == id);

            if ( movie == null )
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie)
            {
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        public ActionResult Details(int? id)
        {
            Movie movie = _context.Movies.Include( m => m.GenreType ).SingleOrDefault( m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }


    }
}