﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_lah263.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//Lillie Heath
//Mission 6

namespace Mission06_lah263.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieApplicationContext _movieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieApplicationContext ma)
        {
            _logger = logger;
            _movieContext = ma;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMovie(NewMovie nm)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(nm);
                _movieContext.SaveChanges();
                return View("Confirmation", nm);

            }
            else
            {
                return View(nm);
            }
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
