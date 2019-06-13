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
    public class CommentController : Controller
    {
        private CommentLogic commentLogic = new CommentLogic();
        [Authorize]
        public IActionResult AddCommentToWorkout(int workoutId , string text)
        {
            Comment commentToAdd = new Comment
            {
                ForeignID = workoutId,
                Text = text,
                Nickname = User.Identity.Name
            };
            commentLogic.AddCommentToWorkout(commentToAdd);
            return new JsonResult(new {message = "Success"});
        }

        [Authorize]
        public IActionResult AddCommentToExercise(int exerciseId, string text)
        {
            Comment commentToAdd = new Comment
            {
                ForeignID = exerciseId,
                Text = text,
                Nickname = User.Identity.Name
            };
            commentLogic.AddCommentToExercise(commentToAdd);
            return new JsonResult(new { message = "Success" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddKudoToComment(int commentId)
        {
            return new JsonResult(new { message = commentLogic.AddKudoToComment(commentId, User.Identity.Name) });
        }

        [Authorize]
        [HttpPost]
        public IActionResult RemoveComment(int commentId)
        {
            commentLogic.RemoveComment(commentId);
            return new JsonResult(new { message = "Success" });
        }
    }
}