using ETicket_Application.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Models
{
    public class Producer: IEntityBase
    {
        public int Id { get; set; }
        [StringLength(150), Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Producer Name")]
        public string ProducerName { get; set; }
        [Required, StringLength(100)]
        public string Biography { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
