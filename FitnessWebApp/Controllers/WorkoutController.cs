using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessWebAppDAL;
using FitnessWebAppLogic;
using FitnessWebAppModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;

namespace FitnessWebApp.Controllers
{
    public class WorkoutController : Controller
    {
        WorkoutPlanLogic workoutPlanLogic = new WorkoutPlanLogic(new WorkoutPlanDAL());
        public IActionResult Index()
        {
            return View(workoutPlanLogic.GetTopWorkoutPlans());
        }

        public IActionResult ShowUserWorkouts(string username)
        {
            return View("Index",workoutPlanLogic.GetWorkoutPlansByUser(username));
        }

        public IActionResult ShowWorkout(string creatornickname, string planname)
        {
            return View(workoutPlanLogic.GetWorkoutPlan(creatornickname, planname));
        }

        public IActionResult ShowWorkoutById(int id)
        {
            return View("ShowWorkout", workoutPlanLogic.GetWorkoutPlanById(id));
        }

        public IActionResult SearchWorkouts()
        {
            return View();
        }

        public IActionResult SearchWorkoutsByName(string name)
        {
            return Json(workoutPlanLogic.SearchWorkoutsByName(name));
        }

        public IActionResult ShowYourWorkouts()
        {
            return View(workoutPlanLogic.GetWorkoutPlansByUser(User.Identity.Name));
        }

        [Authorize]
        public IActionResult AddWorkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewWorkout([Bind("Name , CategoryName")] WorkoutPlan workoutPlan)
        {
            if (workoutPlan.Name == null || workoutPlan.CategoryName == null) 
            {
                return View("AddWorkout");
            }
            workoutPlan.CreatorName = User.Identity.Name;
            workoutPlanLogic.AddWorkoutPlan(workoutPlan);
            return RedirectToAction("ShowYourWorkouts");
        }

        [HttpPost]
        public IActionResult AddExerciseToWorkout(int workoutPlanId , int exerciseId,int repCount,int setCount)
        {
            workoutPlanLogic.AddExerciseToWorkout(workoutPlanId, exerciseId, repCount, setCount);
            return new JsonResult(new { message = "Successfully added exercise" });
        }
        
        public IActionResult AddExercises(WorkoutPlan workoutPlan)
        {
            return View(workoutPlanLogic.GetWorkoutPlanById(workoutPlan.Id));
        }

        public IActionResult RemoveWorkout(int id)
        {
            workoutPlanLogic.RemoveWorkout(id);
            return RedirectToAction("ShowYourWorkouts");
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddKudoToWorkoutplan(int workoutplanId)
        {
            return new JsonResult(new { message = workoutPlanLogic.AddKudoToWorkoutPlan(workoutplanId, User.Identity.Name) });
        }
    }
}