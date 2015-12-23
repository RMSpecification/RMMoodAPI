using System;
using System.Linq;
using MoodAPI.Models;

namespace MoodAPI.Tests
{
    public class TestMoodDbSet : TestDbSet<Mood>
    {
        public override Mood Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.Id == (int)keyValues.Single());
        }
    }
}
