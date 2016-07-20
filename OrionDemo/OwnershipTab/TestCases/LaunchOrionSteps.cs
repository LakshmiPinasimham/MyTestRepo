using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TechTalk.SpecFlow;
using System.Configuration;

namespace OrionSample
{
    [Binding]
    public class LaunchOrionSteps
    {
        public static Application app;
        public static Window currentWindow;



        [Given(@"I have launched Orion App")]
        public void GivenIHaveLaunchedOrionApp()
        {
            app = Application.Launch(ConfigurationManager.AppSettings["path"]);
            Console.WriteLine("App is launching..");

            try
            {
             
                    var loginWindowOkBtn = currentWindow.Get<Button>(SearchCriteria.ByText(ObjectRepository.OwnershipWindow.loginWindowOkButton));
                    loginWindowOkBtn.Click();
              
            }
            catch(Exception exp)
            {
            }
            

        }

        [Given(@"I have clicked on Ownership tab")]
        public void GivenIHaveClickedOnOwnershipTab()
        {
            currentWindow = app.GetWindow(SearchCriteria.ByText("Orion"), InitializeOption.NoCache);
            var ownerShipBtn = currentWindow.Get<Button>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.ownershipButoon));
            ownerShipBtn.Click();

        }

        [Then(@"The Ownership tab should be opened")]
        public void ThenTheOwnershipTabShouldBeOpened()
        {
            var ownershipWindow = app.GetWindow(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.ownershipWindow), InitializeOption.NoCache);
            string title = ownershipWindow.Title;
            Assert.AreEqual(title, "Ownership #1");

        }

        [AfterScenario]
        public void CloseApplication()
        {
            app.Close();

        }
    }

   
}
