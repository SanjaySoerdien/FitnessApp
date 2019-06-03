using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessWebAppModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCategory(string category)
        {
            throw new NotImplementedException(); //TODO MAAK DIT
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteCategory(string category)
        {
            throw new NotImplementedException(); //TODO MAAK DIT
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddExercise(Exercise exercise)
        {
            throw new NotImplementedException(); //TODO MAAK DIT
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteExercise(Exercise exercise)
        {
            throw new NotImplementedException(); //TODO MAAK DIT
        }
    }
}