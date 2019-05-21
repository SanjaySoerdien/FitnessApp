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
            return View();
        }

        [HttpPost]
        public IActionResult SearchForExerciseByCategory(string category)
        {
            List<Exercise> result = new List<Exercise>();
            result = exerciseLogic.GetExercisesByCategory(category);
            return Json(result);
        }
    }
}