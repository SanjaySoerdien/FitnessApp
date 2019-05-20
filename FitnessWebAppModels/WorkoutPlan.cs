using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebAppModels
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string CreatorName { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int Kudos { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
