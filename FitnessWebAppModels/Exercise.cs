using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessWebAppModels
{
    public class Exercise
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string MuscleGroup { get; set; }
        public int SetTarget { get; set; }
        public int RepTarget { get; set; }
        public int Kudos { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
