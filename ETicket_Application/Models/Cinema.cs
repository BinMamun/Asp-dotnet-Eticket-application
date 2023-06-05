using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        [Required, StringLength(150)]
        public string Logo { get; set; }
        [Required, StringLength(50), Display(Name = "Cinema")]
        public string Name { get; set; }
        [ StringLength(200)]
        public string Description { get; set; }
        //Relationships
        public List<Movie> Movies { get; set; }

    }
}
