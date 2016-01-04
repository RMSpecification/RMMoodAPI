using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedMood.Models
{
    public class Mood
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Counter { get; set; }
    }
}