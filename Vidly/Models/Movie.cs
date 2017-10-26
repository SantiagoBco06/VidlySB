using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre de la película es necesario.")]
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
        [Range(1, 20,ErrorMessage = "Se puede agregar mínimo 1 unidad y máximo 20 unidades.")]
        [Display(Name = "In Stock")]
        public byte NumberInStock { get; set; }
        
        [Range(0, 20, ErrorMessage = "Se puede agregar mínimo 1 unidad y máximo 20 unidades.")]
        [Display(Name = "In Stock")]
        public byte NumberAvailable { get; set; }

        public GenreType GenreType { get; set; }

        [Display(Name = "Genre Type")]
        [Required(ErrorMessage = "Se necesita seleccionar un género para la película.")]
        public byte GenreTypeId { get; set; }

    }
    
}