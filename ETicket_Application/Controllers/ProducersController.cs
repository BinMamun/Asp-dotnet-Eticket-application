using ETicket_Application.Data;
using ETicket_Application.Data.ServicesInterface;
using ETicket_Application.Models;
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
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        //Get: Producers/Index
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }

        //Get: Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }

        //Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        //Get: Producers/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if (ModelState.IsValid && producer.Id == id)
            {
                await _service.EditAsync(id, producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }

        //Get: Producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _service.GetByIdAsync(id));
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
