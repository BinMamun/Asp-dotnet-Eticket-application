using ETicket_Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _db;
        public CinemasController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {           
            return View(await _db.Cinemas.ToListAsync());
        }
    }
}
