﻿using ETicket_Application.Data;
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
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllActorsAsync());
        }
        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(actor);
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {    
            return View(await _service.ActorByIdAsync(id));
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {            
            return View(await _service.ActorByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _service.EditAsync(id, actor);
                return RedirectToAction("Index");
            }
            return View(actor);
        }
    }
}
