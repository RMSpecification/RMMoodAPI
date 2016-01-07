using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Net;
using MoodAPI.Models;
using MoodAPI.Controllers;

namespace MoodAPI.Tests
{
    [TestClass]
    public class TestMoodController
    {                
        [TestMethod]
        public void GetMoods_ShouldReturnAllMoods()
        {
            var context = new TestMoodContext();
            context.Moods.Add(new Mood { Id = 1, Description = "Demo1", Counter = 20 });
            context.Moods.Add(new Mood { Id = 2, Description = "Demo2", Counter = 30 });
            context.Moods.Add(new Mood { Id = 3, Description = "Demo3", Counter = 40 });

            var controller = new MoodsController(context);
            var result = controller.GetMoods() as TestMoodDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Local.Count);
        }

        Mood GetDemoMood()
        {
            return new Mood() { Id = 3, Description = "Demo name", Counter = 5 };
        }
    }
}
