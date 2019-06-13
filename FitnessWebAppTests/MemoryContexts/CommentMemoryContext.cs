using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppTests.MemoryContexts
{
    class CommentMemoryContext : ICommentContext
    {
        public List<Comment> GetCommentsByWorkoutplan(int id)
        {
            /*return new List<Comment>()
            {
                new Comment()
                {
                    ForeignID = 1,
                    ID = 
                }
            };*/
            return null;
        }

        public List<Comment> GetCommentsByExercise(int id)
        {
            throw new NotImplementedException();
        }

        public void AddCommentToWorkout(Comment commentToAdd)
        {
            throw new NotImplementedException();
        }

        public void AddCommentToExercise(Comment commentToAdd)
        {
            throw new NotImplementedException();
        }

        public string AddKudoToComment(int commentId, string nickname)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(int commentId)
        {
            throw new NotImplementedException();
        }
    }
}
