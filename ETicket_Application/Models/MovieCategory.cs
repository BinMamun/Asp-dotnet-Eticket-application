using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Models
{
    public class MovieCategory
    {
        public int MovieCategoryId { get; set; }
        [Required, StringLength(50)]
        public string Category{ get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        //Relationships
        public List<Movie> Movies { get; set; }

    }
}
