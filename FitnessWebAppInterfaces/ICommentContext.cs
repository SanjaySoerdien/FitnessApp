using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppModels;

namespace FitnessWebAppInterfaces
{
    public interface ICommentContext
    {
        List<Comment> GetCommentsByWorkoutplan(int id);
        List<Comment> GetCommentsByExercise(int id);
        void AddCommentToWorkout(Comment commentToAdd);

        void AddCommentToExercise(Comment commentToAdd);

    }
}
