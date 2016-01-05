using TechTalk.SpecFlow;
using RedMood.Controllers;
using RedMood.Models;
using NUnit.Framework;
using System.Web.Mvc;

namespace Mood.Specs
{
    [Binding]
    public class RegisterAHappyMoodSteps
    {
        int initCounter;
        int moodIndex;
        MoodService service;

        [Given(@"I have entered the RedMood application")]
        public void GivenIHaveEnteredTheRedMoodApplication()
        {
            service = new MoodService();
        }
        
        [Given(@"I feel happy")]
        public void GivenIFeelHappy()
        {
            moodIndex = 1; //Happysmiley in the database has id = 1
        }

        [Given(@"the counter for the happy smiley is set to a value")]
        public async void GivenTheCounterForTheHappySmileyIsSetToAValue()
        {
            System.Collections.Generic.List<RedMood.Models.Mood> moods = await service.GetMoodsAsync();
            initCounter = moods[moodIndex].Counter;
        }

        [When(@"I press the happy smiley icon")]
        public async void WhenIPressTheHappySmileyIcon()
        {
            await service.Increase(moodIndex);
        }

        [Then(@"the happy smiley counter value should be increased with (.*)")]
        public async void ThenTheHappySmileyCounterValueShouldBeIncreasedWith(int increase)
        {

            System.Collections.Generic.List<RedMood.Models.Mood> moods = await service.GetMoodsAsync();
            if (moods != null)
            {
                Assert.AreEqual(moods[moodIndex].Counter, initCounter + increase);
            }
        }
    }
}
