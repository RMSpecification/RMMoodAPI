using TechTalk.SpecFlow;
using RedMood.Controllers;
using RedMood.Models;
using NUnit.Framework;
using System.Web.Mvc;
using System.Linq;

namespace Mood.Specs
{
    [Binding]
    public class RegisterAHappyMoodSteps
    {
        int initCounter;
        int moodId;
        MoodService service;

        [Given(@"I have entered the RedMood application")]
        public void GivenIHaveEnteredTheRedMoodApplication()
        {
            service = new MoodService();
        }
        
        [Given(@"I feel happy")]
        public void GivenIFeelHappy()
        {
            System.Collections.Generic.List<RedMood.Models.Mood> moods = service.GetMoodsAsync().GetAwaiter().GetResult(); ;
            moodId = (moods.Find(x => x.Description.Contains("Happy"))).Id;
        }

        [Given(@"the counter for the happy smiley is set to a value")]
        public void GivenTheCounterForTheHappySmileyIsSetToAValue()
        {
            RedMood.Models.Mood mood = GetMood();
            initCounter = mood.Counter;
        }

        [When(@"I press the happy smiley icon")]
        public void WhenIPressTheHappySmileyIcon()
        {
            service.Increase(moodId).GetAwaiter().GetResult();
        }

        [Then(@"the happy smiley counter value should be increased with (.*)")]
        public void ThenTheHappySmileyCounterValueShouldBeIncreasedWith(int increase)
        {
            RedMood.Models.Mood mood = GetMood();
            if ( mood != null)
            {
                Assert.AreEqual(mood.Counter, initCounter + increase);
            }
        }

        private RedMood.Models.Mood GetMood()
        {            
            return service.GetMoodAsync(moodId).GetAwaiter().GetResult();
        }
    }
}
