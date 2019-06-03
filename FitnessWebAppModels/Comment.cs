using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebAppModels
{
    public class Comment
    {
        public int ID { get; set; }
        public int ForeignID { get; set; }
        public string Nickname { get; set; }
        public int Kudos { get; set; }
        public string Text { get; set; }
    }
}
