using ETicket_Application.Data.Base;
using ETicket_Application.Data.ServicesInterface;
using ETicket_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Data.ServiceClasses
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService 
    { 
        public MoviesService(AppDbContext context) : base(context) { }
    }
}
