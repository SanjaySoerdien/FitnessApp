using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebAppModels
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public int SetTarget { get; set; }
        public int RepTarget { get; set; }
        public int Kudos { get; set; }
        public string Description { get; set; } //todo fix in dal enzo en in DB!
        public List<Comment> Comments { get; set; }
    }
}
