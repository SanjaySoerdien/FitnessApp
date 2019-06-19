using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppDAL.MemoryContexts;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL
{
    public class CommentRepo
    {
        private ICommentContext context;

        public CommentRepo(ICommentContext context)
        {
            this.context = context;
        }

        public void AddCommentToWorkout(Comment commentToAdd)
        {
            context.AddCommentToWorkout(commentToAdd);
        }

        public void AddCommentToExercise(Comment commentToAdd)
        {
            context.AddCommentToExercise(commentToAdd);
        }

        public ErrorMessage AddKudoToComment(int commentId,string nickname)
        {
            return context.AddKudoToComment(commentId, nickname);
        }

        public void RemoveComment(int commentId)
        {
            context.RemoveComment(commentId);
        }
    }
}
