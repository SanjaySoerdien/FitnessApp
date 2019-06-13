using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class CommentRepo
    {
        private ICommentContext context;

        public CommentRepo()
        {
            context = new CommentDAL();
            //todo Add mock data voor unit tests
        }
        public void AddCommentToWorkout(Comment commentToAdd)
        {
            context.AddCommentToWorkout(commentToAdd);
        }

        public void AddCommentToExercise(Comment commentToAdd)
        {
            context.AddCommentToExercise(commentToAdd);
        }

        public string AddKudoToComment(int commentId,string nickname)
        {
            return context.AddKudoToComment(commentId, nickname);
        }

        public void RemoveComment(int commentId)
        {
            context.RemoveComment(commentId);
        }
    }
}
