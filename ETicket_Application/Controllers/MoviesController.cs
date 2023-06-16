using ETicket_Application.Data;
using ETicket_Application.Data.ServicesInterface;
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
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _db.Movies
        //        .Include(x => x.MovieCategory)
        //        .Include(x => x.Producer)
        //        .Include(x=> x.Cinema)
        //        .ToListAsync()); 
        //}

        //public async Task<IActionResult> ListIndex()
        //{
        //    ViewBag.Count = _db.Movies.Count();
        //    return View(await _db.Movies
        //        .Include(x => x.MovieCategory)
        //        .Include(x => x.Producer)
        //        .Include(x => x.Cinema)
        //        .ToListAsync());
        //}
        //public async Task<IActionResult> MoviesByProducers(int id)
        //{
        //    ViewBag.ProducerName = _db.Producers.First(x => x.Id == id).ProducerName;            
        //    ViewBag.Count = _db.Movies.Where(x => x.Id == id).Count();
        //    return View(await _db.Movies
        //        .Where(x=> x.Id==id)
        //        .Include(x => x.MovieCategory)
        //        .Include(x => x.Producer)
        //        .ToListAsync());
        //}
    }
}
