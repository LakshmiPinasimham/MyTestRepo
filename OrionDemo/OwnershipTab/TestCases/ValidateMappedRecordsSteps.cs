using System;
using TechTalk.SpecFlow;

namespace OrionDemo.OwnershipTab.TestCases
{
    [Binding]
    public class SearchforUnmappedSteps
    {
        [Given(@"I have clicked on the USSM button in Ownership Window")]
        public void GivenIHaveClickedOnTheUSSMButtonInOwnershipWindow()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have selected the Form Type  as '(.*)'")]
        public void GivenIHaveSelectedTheFormTypeAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have selected the mapping type as '(.*)'")]
        public void GivenIHaveSelectedTheMappingTypeAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I have clicked on Search button")]
        public void WhenIHaveClickedOnSearchButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Mapped records should  display")]
        public void ThenMappedRecordsShouldDisplay()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
