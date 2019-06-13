using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessWebAppModels
{
    public class Change
    {
        //todo add 2x string en vull in db enzo
        [Display(Name = "Change")]
        public string changeText { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Time")]
        public DateTime time { get; set; }
    }
}
