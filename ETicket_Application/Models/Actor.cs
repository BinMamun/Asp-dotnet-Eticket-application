using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Models
{
    public class Actor
    {
        
        public int ActorId { get; set; }
        [StringLength(150), Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; } = "https://img.freepik.com/free-vector/gradient-no-photo-sign_23-2149276163.jpg?w=740&t=st=1686590099~exp=1686590699~hmac=fd347fb35b69b2dc627ae3d944288ab4f2fa6567f03f67d954ba9e74c7c3431a";
        [Required, StringLength(50), Display(Name = "Actor Name")]
        public string ActorName { get; set; }
        [Required,StringLength(200)]
        public string Biography { get; set; }

        //Relationships
        //Actor_Movie
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
