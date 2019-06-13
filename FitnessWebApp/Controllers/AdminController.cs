using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessWebAppLogic;
using FitnessWebAppModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        AdminLogic adminLogic = new AdminLogic();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(string category)
        {
            adminLogic.AddCategory(category);
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult ChangeCategory(string categoryNew, string categoryOld)
        {
            adminLogic.ChangeCategory(categoryNew, categoryOld);
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult DeleteCategory(string category)
        {
            adminLogic.DeleteCategory(category);
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AddExercise(Exercise exercise)
        {

            if (exercise.Name != null && exercise.MuscleGroup != null && exercise.Description != null)
            {
                adminLogic.AddExercise(exercise);
            }
            return View("ExerciseView");
        }

        [HttpPost]
        public IActionResult DeleteExercise(int id)
        {
            adminLogic.DeleteExercise(id);
            throw new NotImplementedException();
        }

        public IActionResult ExerciseView()
        {
            return View();
        }

        public IActionResult CategoriesView()
        {
            return View();
        }
    }
}