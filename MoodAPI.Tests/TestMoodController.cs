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
        public void PostMood_ShouldReturnSameMood()
        {
            var controller = new MoodsController(new TestMoodContext());

            var item = GetDemoMood();

            var result =
                controller.PostMood(item) as CreatedAtRouteNegotiatedContentResult<Mood>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Counter, item.Counter);
        }
                
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

        [TestMethod]
        public void DeleteMood_ShouldReturnOK()
        {
            var context = new TestMoodContext();
            var item = GetDemoMood();
            context.Moods.Add(item);

            var controller = new MoodsController(context);
            var result = controller.DeleteMood(3) as OkNegotiatedContentResult<Mood>;

            Assert.IsNotNull(result);
            Assert.AreEqual(item.Id, result.Content.Id);
        }

        Mood GetDemoMood()
        {
            return new Mood() { Id = 3, Description = "Demo name", Counter = 5 };
        }
    }
}
