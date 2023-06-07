using ETicket_Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _db;
        public MoviesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Movies
                .Include(x => x.MovieCategory)
                .Include(x => x.Producer)
                .Include(x=> x.Cinema)
                .ToListAsync()); 
        }

        public async Task<IActionResult> ListIndex()
        {
            return View(await _db.Movies
                .Include(x => x.MovieCategory)
                .Include(x => x.Producer)
                .Include(x => x.Cinema)
                .ToListAsync());
        }
        public async Task<IActionResult> MoviesByProducers(int id)
        {
            ViewBag.ProducerName = _db.Producers.First(x => x.ProducerId == id).ProducerName;            
            ViewBag.Count = _db.Movies.Where(x => x.ProducerId == id).Count();
            return View(await _db.Movies
                .Where(x=> x.ProducerId==id)
                .Include(x => x.MovieCategory)
                .Include(x => x.Producer)
                .ToListAsync());
        }
    }
}
