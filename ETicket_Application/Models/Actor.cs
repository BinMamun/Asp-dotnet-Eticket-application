using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        [Required, StringLength(150), Display(Name ="Profile Picture")]
        public string ProfilePicture { get; set; }
        [Required, StringLength(50), Display(Name = "Actor Name")]
        public string ActorName { get; set; }
        [StringLength(200)]
        public string Biography { get; set; }

        //Relationships
        //Actor_Movie
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
