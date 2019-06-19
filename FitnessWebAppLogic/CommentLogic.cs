using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppLogic
{
    public class CommentLogic
    {
        private CommentRepo commentRepo;

        public CommentLogic(ICommentContext context)
        {
            commentRepo = new CommentRepo(context);
        }
        public void AddCommentToWorkout(Comment commentToAdd)
        {
            commentRepo.AddCommentToWorkout(commentToAdd);
        }

        public void AddCommentToExercise(Comment commentToAdd)
        {
            commentRepo.AddCommentToExercise(commentToAdd);
        }

        public ErrorMessage AddKudoToComment(int commentId,string nickname)
        {
            return commentRepo.AddKudoToComment(commentId,nickname);
        }

        public void RemoveComment(int commentId)
        {
            commentRepo.RemoveComment(commentId);
        }
    }
}
