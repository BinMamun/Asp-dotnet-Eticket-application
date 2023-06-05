using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Models
{
    public class Actor_Movie
    {
        //[Required, ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        //[Required, ForeignKey("Actor")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
