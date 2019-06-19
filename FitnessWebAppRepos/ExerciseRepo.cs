using System.Collections.Generic;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppRepos
{
    public class ExerciseRepo
    {
        private readonly IExerciseContext context;

        public ExerciseRepo(IExerciseContext exerciseContext)
        {
            context = exerciseContext;
        }

        public Exercise GetExercise(string name)
        {
            return context.GetExercise(name);
        }

        public Exercise GetExercise(int id)
        {
            return context.GetExercise(id);
        }

        public List<Exercise> GetTopExercises()
        {
            return context.GetTopExercises();
        }

        public List<string> GetAllCategories()
        {
            return context.GetAllCategories();
        }

        public List<Exercise> GetExercisesByCategory(string category)
        {
            return context.GetExercisesByCategory(category);
        }
        public ErrorMessage AddKudoToExercise(int commentId, string nickname)
        {
            return context.AddKudoToExercise(commentId, nickname);
        }
    }
}
