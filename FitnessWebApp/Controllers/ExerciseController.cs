using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessWebAppLogic;
using FitnessWebAppModels;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
    public class ExerciseController : Controller
    {
        ExerciseLogic exerciseLogic = new ExerciseLogic();
        public IActionResult Index()
        {
            return View(exerciseLogic.GetTopExercises());
        }

        public IActionResult ShowExercise(int id)
        {
            return View(exerciseLogic.GetExercise(id));
        }

        public IActionResult SearchForExercise()
        {
            return View(exerciseLogic.GetAllCategories());
        }

        [HttpPost]
        public IActionResult SearchForExerciseByCategory(string category)
        {
            return Json(exerciseLogic.GetExercisesByCategory(category));
        }
    }
}