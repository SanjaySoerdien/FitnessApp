using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebAppModels
{
    public class WorkoutPlan
    {
        private int id;
        private string name;
        private int kudos;
        private List<Excercise> excercises = new List<Excercise>();
        private List<Comment> comments = new List<Comment>();
    }
}
