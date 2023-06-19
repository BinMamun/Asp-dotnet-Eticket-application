using ETicket_Application.Data.Base;
using ETicket_Application.Data.ServicesInterface;
using ETicket_Application.Data.ViewModels;
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
                    .Include(mc => mc.MovieCategory)
                    .Include(am => am.Actors_Movies)
                    .ThenInclude(a => a.Actor)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByProducersAsync(int id)
        {
            return await _context.Movies
                    .Include(p => p.Producer)
                    .Where(p => p.ProducerId == id)
                    .Include(mc => mc.MovieCategory)
                    .ToListAsync();
        }

        public async Task<MovieDropDownVM> GetMovieDropDownValues()
        {
            var responce = new MovieDropDownVM()
            {
                Actors = await _context.Actors.OrderBy(a => a.ActorName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(a => a.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(a => a.ProducerName).ToListAsync(),
                MovieCategories = await _context.MovieCategories.OrderBy(a => a.Category).ToListAsync()
            };
            return responce;
        }

        public int CountAsync()
        {
            return _context.Movies.Count();
        }

        public int CountByProducer(int id)
        {
            return _context.Movies.Where(x => x.ProducerId == id).Count();
        }

        public async Task AddNewMovieAsync(MovieViewModel data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId,
                MovieCategoryId = data.MovieCategoryId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                Image = data.Image
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();
            foreach (var actorId in data.ActorIds)
            {
                var actorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(actorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}
