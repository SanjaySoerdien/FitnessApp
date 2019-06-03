using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nickname field is required!")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Username field is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password field is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password field is required!")]
        public string ConfirmPassword { get; set; }
    }
}
