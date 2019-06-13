using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL;
using FitnessWebAppModels;

namespace FitnessWebAppLogic
{
    public class CommentLogic
    {
        private CommentRepo commentRepo = new CommentRepo();
        public void AddCommentToWorkout(Comment commentToAdd)
        {
            commentRepo.AddCommentToWorkout(commentToAdd);
        }

        public void AddCommentToExercise(Comment commentToAdd)
        {
            commentRepo.AddCommentToExercise(commentToAdd);
        }
/*

        public IActionResult AddKudoToWorkoutplan(int commentId)
        {
            throw new NotImplementedException(); //TODO MAAK DIT
        }

        public IActionResult RemoveComment(int commentId)
        {
            throw new NotImplementedException(); //TODO MAAK DIT
        }*/
    }
}
