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
    public class CommentController : Controller
    {
        private CommentLogic commentLogic = new CommentLogic(new CommentDAL());
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
            string result = "Error";
            ErrorMessage check = commentLogic.AddKudoToComment(commentId, User.Identity.Name);
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
            return new JsonResult(new { message =  result});
        }

        [Authorize]
        public IActionResult RemoveComment(int commentId)
        {
            commentLogic.RemoveComment(commentId);
            return new JsonResult(new { message = "Success" });
        }
    }
}