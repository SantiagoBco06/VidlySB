using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la película es necesario.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Es necesario poner la fecha de estreno.")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Es necesario poner la fecha en la que se agregó.")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Es necesario agregar la cantidad de unidades que se van a registrar.")]
        [Range(1, 20, ErrorMessage = "Se puede agregar mínimo 1 unidad y máximo 20 unidades.")]
        public byte NumberInStock { get; set; }

        public GenreTypeDto GenreType { get; set; }

        [Required(ErrorMessage = "Se necesita seleccionar un género para la película.")]
        public byte GenreTypeId { get; set; }

    }
}