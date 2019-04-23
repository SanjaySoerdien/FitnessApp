using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebAppModels
{
    public class WorkoutPlan
    {
        public string CreatorName { get; set; }
        public string Name { get; set; }
        public int Kudos { get; set; }
        public List<Excercise> Excercises { get; set; }
    }
}
