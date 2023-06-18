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
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync(x=> x.Cinema, y=> y.MovieCategory, z=> z.Producer));
        }

        public async Task<IActionResult> ListIndex()
        {
            ViewBag.Count = _service.CountAsync();
            return View(await _service.GetAllAsync(x => x.Cinema, y => y.MovieCategory, z => z.Producer));
        }
        
        public async Task<IActionResult> MoviesByProducers(int id)
        {
            ViewBag.Count = _service.CountByProducer(id);
            return View(await _service.GetMoviesByProducersAsync(id));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.GetMovieByIdAsync(id));
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
