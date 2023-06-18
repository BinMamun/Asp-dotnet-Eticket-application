using ETicket_Application.Data.Base;
using ETicket_Application.Data.ServicesInterface;
using ETicket_Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ETicket_Application.Data.ServiceClasses
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService 
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies
                    .Include(c => c.Cinema)
                    .Include(p => p.Producer)
                    .Include(mc=> mc.MovieCategory)
                    .Include(am => am.Actors_Movies)
                    .ThenInclude(a => a.Actor)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByProducersAsync(int id)
        {     
            return await _context.Movies
                    .Include(p => p.Producer)
                    .Where(p => p.ProducerId == id)
                    .Include(mc=> mc.MovieCategory)
                    .ToListAsync();
        }

        public int CountAsync()
        {
            return  _context.Movies.Count();
        }      

        public int CountByProducer(int id)
        {
            return _context.Movies.Where(x=> x.ProducerId == id).Count();
        }
    }
}
