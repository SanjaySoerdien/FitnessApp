using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessWebAppModels
{
    public class Change
    {
        [Display(Name = "Change")]
        public string changeText { get; set; }
        [Display(Name = "Time")]
        public DateTime time { get; set; }
    }
}
