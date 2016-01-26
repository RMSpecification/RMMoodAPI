using TechTalk.SpecFlow;
using RedMood.Controllers;
using NUnit.Framework;
using System;

namespace Mood.Specs
{
    [Binding]
    public class RegisterMoodsSteps
    {
        int initCounter;
        int moodId;
        MoodService service;

        private void IncreaseSmileyCounter()
        {
            service.Increase(moodId).GetAwaiter().GetResult();
        }

        private RedMood.Models.Mood GetMood()
        {
            return service.GetMoodAsync(moodId).GetAwaiter().GetResult();
        }

        private System.Collections.Generic.List<RedMood.Models.Mood> GetMoods()
        {
            return service.GetMoodsAsync().GetAwaiter().GetResult();
        }

        private void SetCounter()
        {
            initCounter = GetMood().Counter;
        }

        [Given(@"I have entered the RedMood application")]
        public void GivenIHaveEnteredTheRedMoodApplication()
        {
            service = new MoodService();
        }

        [Given(@"I feel happy")]
        public void GivenIFeelHappy()
        {            
            moodId = (GetMoods().Find(x => x.Description.Contains("Happy"))).Id;
        }

        [Given(@"the counter for the happy smiley is set to a value")]
        public void GivenTheCounterForTheHappySmileyIsSetToAValue()
        {
            SetCounter(); //will set counter with moodindex of Happy
        }

        [When(@"I press the happy smiley icon")]
        public void WhenIPressTheHappySmileyIcon()
        {
            IncreaseSmileyCounter();            
        }
        
        [Given(@"I feel sad")]
        public void GivenIFeelSad()
        {
            moodId = (GetMoods().Find(x => x.Description.Contains("Sad"))).Id;
        }
        
        [Given(@"the counter for the sad smiley is set to a value")]
        public void GivenTheCounterForTheSadSmileyIsSetToAValue()
        {
            SetCounter(); //will set counter with moodindex of Sad
        }
        
        [When(@"I press the sad smiley icon")]
        public void WhenIPressTheSadSmileyIcon()
        {
            IncreaseSmileyCounter();
        }
        
        [Then(@"the clicked smiley counter value should be increased with (.*)")]
        public void ThenTheClickedSmileyCounterValueShouldBeIncreasedWith(int increase)
        {
            RedMood.Models.Mood mood = GetMood();
            if (mood != null)
            {
                Assert.AreEqual(mood.Counter, initCounter + increase);
            }
        }
    }
}
