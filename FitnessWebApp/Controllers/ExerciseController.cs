using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessWebAppLogic;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
    public class ExerciseController : Controller
    {
        ExerciseLogic exerciseLogic = new ExerciseLogic();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowExercise(int id)
        {
            return View(exerciseLogic.GetExercise(id));
        }

    }
}