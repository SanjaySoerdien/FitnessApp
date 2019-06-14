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
        ExerciseLogic exerciseLogic = new ExerciseLogic();
        public IActionResult Index()
        {
      
            return View(adminLogic.GetRecentChanges());
        }

        [HttpPost]
        public IActionResult AddCategory(string category)
        {
            if (adminLogic.AddCategory(category) > 0)
            {
                return new JsonResult(new { message = "Successfully added category" });
            }
            return new JsonResult(new { message = "Failed to add category" });
        }

        [HttpPost]
        public IActionResult ChangeCategory(string categoryNew, string categoryOld)
        {
            if (adminLogic.ChangeCategory(categoryNew, categoryOld) > 0)
            {
                return new JsonResult(new { message = "Successfully changed category" });
            }
            return new JsonResult(new { message = "Failed to change category" });
        }

        [HttpPost]
        public IActionResult DeleteCategory(string category)
        {

            if (adminLogic.DeleteCategory(category) > 0)
            {
                return new JsonResult(new { message = "Successfully deleted category" });
            }
            return new JsonResult(new { message = "Failed to delete category" });
        }

        [HttpPost]
        public IActionResult AddExercise(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                adminLogic.AddExercise(exercise);
            }
            return View("ExerciseView");
        }

        public IActionResult DeleteExercise(int id)
        {
            adminLogic.DeleteExercise(id);
            return View("ExerciseView");
        }

        public IActionResult ExerciseView()
        {
            return View();
        }

        public IActionResult CategoriesView()
        {
            return View(exerciseLogic.GetAllCategories());
        }

        public IActionResult ShowMoreChanges()
        {
            return View(adminLogic.GetMoreChanges());
        }
    }
}