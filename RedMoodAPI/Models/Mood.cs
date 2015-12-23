using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedMoodAPI.Models
{
    public class Mood
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int count { get; set; }
    }
}