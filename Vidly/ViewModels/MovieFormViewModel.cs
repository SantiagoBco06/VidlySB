using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "El nombre de la película es necesario.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Es necesario poner la fecha de estreno.")]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Es necesario poner la fecha en la que se agregó.")]
        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Es necesario agregar la cantidad de unidades que se van a registrar.")]
        [Range(1, 20, ErrorMessage = "Se puede agregar mínimo 1 unidad y máximo 20 unidades.")]
        [Display(Name = "In Stock")]
        public byte NumberInStock { get; set; }

        [Required(ErrorMessage = "Se necesita seleccionar un género para la película.")]
        public byte GenreTypeId { get; set; }

        public string Title {
            get {
                if (Id != 0)
                {
                    return "Edit";
                }
                return "New";
            }
        }
        public MovieFormViewModel()
        {
            Id = 0;
            DateAdded = DateTime.Today;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
            GenreTypeId = movie.GenreTypeId;
            DateAdded = movie.DateAdded;
        }

    }
}