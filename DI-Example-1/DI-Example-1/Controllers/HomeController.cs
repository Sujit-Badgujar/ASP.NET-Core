﻿using Microsoft.AspNetCore.Mvc;
using Services;

namespace DI_Example_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly CitiesService _citiesService;

        public HomeController() 
        {
            _citiesService = new CitiesService();
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();

            return View(cities); 
        }
    }
}
