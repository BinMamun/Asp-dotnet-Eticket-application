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
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController (IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {            
            return View(await _service.GetAllAsync());
        }
    }
}
