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
    public class WorkoutController : Controller
    {
        WorkoutPlanLogic workoutPlanLogic = new WorkoutPlanLogic();
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
            //TODO maak deze view en voeg add functies toe enzo 
        }

        [Authorize]
        public IActionResult AddWorkout()
        {
            return View();
        }

        public IActionResult CreateNewWorkout([Bind("CreatorName", "CategoryName")] WorkoutPlan workoutPlan)
        {
            if (!ModelState.ContainsKey("Name") && !ModelState.ContainsKey("CategoryName"))
            {
                return View("AddWorkout");
            }
            workoutPlan.CreatorName = User.Identity.Name;
            workoutPlanLogic.AddWorkoutPlan(workoutPlan); //TODO maak in DAL en IN DB
            return View("ShowYourWorkouts");
        }
    }
}