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
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {            
            return View(await _service.GetAllActors());
        }
        //Get: Actors?Create

        public IActionResult Create()
        {
            return View();
        }
    }
}
