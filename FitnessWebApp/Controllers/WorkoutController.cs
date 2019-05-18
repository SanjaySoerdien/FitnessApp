﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessWebAppLogic;
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

        public IActionResult ShowWorkout(string creatornickname, string planname)
        {
            return View(workoutPlanLogic.GetWorkoutPlanExcercises(creatornickname, planname));
        }
    }
}