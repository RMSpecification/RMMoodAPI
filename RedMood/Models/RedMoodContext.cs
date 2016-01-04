using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedMood.Models
{
    public class RedMoodContext
    {
    
        public RedMoodContext()
        {
            Moods = new List<Models.Mood>();
        }

        public List<RedMood.Models.Mood> Moods { get; set; }
    }
}
