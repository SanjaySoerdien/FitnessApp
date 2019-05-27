using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;


namespace FitnessWebAppModels
{
    public class User
    {
        [Required(ErrorMessage = "Nickname field is required!")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Username field is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password field is required!")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
