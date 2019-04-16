using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using FitnessWebAppModels.Enums;


namespace FitnessWebAppModels
{
    public class User
    {
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Username field is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password field is required!")]
        public string Password { get; set; }
        public List<WorkoutPlan> WorkoutPlans { get; set; }
        public Role Role { get; set; }
    }
}
