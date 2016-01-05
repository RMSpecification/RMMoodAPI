using TechTalk.SpecFlow;
using RedMood.Controllers;
using RedMood.Models;
using NUnit.Framework;
using System.Web.Mvc;

namespace RedMood.Specs
{
    [Binding]
    public class RegisterAHappyMoodSteps
    {
        int initCounter;
        int moodIndex;
        MoodController controller;

        [Given(@"I have entered the RedMood application")]
        public void GivenIHaveEnteredTheRedMoodApplication()
        {
            controller = new MoodController();
        }
        
        [Given(@"I feel happy")]
        public void GivenIFeelHappy()
        {
            moodIndex = 1; //Happysmiley in the database has id = 1
        }

        [Given(@"the counter for the happy smiley is currently at (.*)")]
        public void GivenTheCounterForTheHappySmileyIsCurrentlyAt(int counter)
        {
            initCounter = counter;
        }

        [When(@"I press the happy smiley icon")]
        public async void WhenIPressTheHappySmileyIcon()
        {
            await controller.Increase(moodIndex);
        }


        [Then(@"the happy smiley counter shown on the web page should be (.*)")]
        public async void ThenTheHappySmileyCounterShownOnTheWebPageShouldBe(int increasedCounter)
        {
            ActionResult result = await controller.Index();
            Assert.IsInstanceOf<ViewResult>(result, "The returning model is not Mood");
            ViewResult vResult = result as ViewResult;
            if (vResult != null)
            {
                Assert.IsInstanceOf<Mood>(vResult.Model, "The returning model is not Mood");
                Mood model = vResult.Model as Mood;
                if (model != null)
                {
                    Assert.AreEqual(model.Counter, increasedCounter);
                }
            }
        }

    }
}
