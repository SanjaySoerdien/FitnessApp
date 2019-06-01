using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult AddCommentToWorkout(int workoutId , string text)
        {
            //TODO maak enzo
            return new JsonResult(new {message = "Success"});
        }

        public IActionResult AddCommentToExercise(int exerciseId, string text)
        {
            //TODO maak enzo v2
            return new JsonResult(new { message = "Success" });
        }
    }
}