using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessWebAppModels
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Creator name is required")]
        public string CreatorName { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Category is required!")]
        public string CategoryName { get; set; }
        public int Kudos { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
