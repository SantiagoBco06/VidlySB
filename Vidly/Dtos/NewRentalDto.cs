using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class NewRentalDto
    {

        public byte Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<int> MovieIds { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

    }
}