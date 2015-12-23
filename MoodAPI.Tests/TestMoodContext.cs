using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoodAPI.Models;

namespace MoodAPI.Tests
{
        public class TestMoodContext : IMoodContext
        {
            public TestMoodContext()
            {
                this.Moods = new TestMoodDbSet();
            }

            public DbSet<Mood> Moods { get; set; }
            
            public int SaveChanges()
            {
                return 0;
            }

            public void MarkAsModified(Mood item) { }
            public void Dispose() { }
        }
}
