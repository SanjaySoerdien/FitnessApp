using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessWebAppDAL;
using FitnessWebAppInterfaces;
using FitnessWebAppLogic;
using FitnessWebAppModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
    public class ExerciseController : Controller
    {
        ExerciseLogic exerciseLogic = new ExerciseLogic(new ExerciseDAL());
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

        [HttpPost]
        public IActionResult GetAllCategories()
        {
            return Json(exerciseLogic.GetAllCategories());
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddKudoToExercise(int exerciseId)
        {
            string result = "Error";
            ErrorMessage check = exerciseLogic.AddKudoToExercise(exerciseId, User.Identity.Name);
            if (check == ErrorMessage.Succes)
            {
                result = "Succesfully added kudo";
            }
            else if (check == ErrorMessage.Unsuccesfull)
            {
                result = "Unsuccesfull";
            }
            else if (check == ErrorMessage.Duplicate)
            {
                result = "Already added a kudo!";
            }
            return new JsonResult(new { message = result });
        }
    }
}