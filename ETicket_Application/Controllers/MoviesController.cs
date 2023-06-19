using ETicket_Application.Data;
using ETicket_Application.Data.ServicesInterface;
using ETicket_Application.Data.ViewModels;
using ETicket_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

        public async Task<IActionResult> Create()
        {
            var movieDropDOwn = await _service.GetMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDOwn.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDOwn.Producers, "Id", "ProducerName");
            ViewBag.Actors = new SelectList(movieDropDOwn.Actors, "Id", "ActorName");
            ViewBag.Categories = new SelectList(movieDropDOwn.MovieCategories, "Id", "Category");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieViewModel mv)
        {
            if (ModelState.IsValid)
            {
                await _service.AddNewMovieAsync(mv);
                return RedirectToAction("ListIndex");
            }
            var movieDropDOwn = await _service.GetMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDOwn.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDOwn.Producers, "Id", "ProducerName");
            ViewBag.Actors = new SelectList(movieDropDOwn.Actors, "Id", "ActorName");
            ViewBag.Categories = new SelectList(movieDropDOwn.MovieCategories, "Id", "Category");
            return View(mv);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDropDOwn = await _service.GetMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDOwn.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDOwn.Producers, "Id", "ProducerName");
            ViewBag.Actors = new SelectList(movieDropDOwn.Actors, "Id", "ActorName");
            ViewBag.Categories = new SelectList(movieDropDOwn.MovieCategories, "Id", "Category");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MovieViewModel mv)
        {
            if (ModelState.IsValid)
            {
                await _service.AddNewMovieAsync(mv);
                return RedirectToAction("ListIndex");
            }
            var movieDropDOwn = await _service.GetMovieDropDownValues();
            ViewBag.Cinemas = new SelectList(movieDropDOwn.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDOwn.Producers, "Id", "ProducerName");
            ViewBag.Actors = new SelectList(movieDropDOwn.Actors, "Id", "ActorName");
            ViewBag.Categories = new SelectList(movieDropDOwn.MovieCategories, "Id", "Category");
            return View(mv);
        }
    }
}


