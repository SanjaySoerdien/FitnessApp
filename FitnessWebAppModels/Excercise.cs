using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebAppModels
{
    public class Excercise
    {
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
