using System;

using TestStack.White;
using TestStack.White.Factory;

using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

using TestStack.White.UIItems.WindowItems;
 

using TechTalk.SpecFlow;
 
using NUnit.Framework;


namespace OrionDemo.OwnershipTab.TestCases
{
    [Binding]
    public class ValidateMappedRecordsSteps
    {

        public static Application app;
        public static Window currentWindow;
        public string mappedCellValue;

        [Given(@"I have clicked on the USSM button in Ownership Window")]
        public void GivenIHaveClickedOnTheUSSMButtonInOwnershipWindow()
        {
            currentWindow = LaunchOrionSteps.app.GetWindow(SearchCriteria.ByText("Ownership #1"), InitializeOption.NoCache);
            var ussmBtn = currentWindow.Get<Button>(SearchCriteria.ByText(ObjectRepository.OwnershipWindow.ussmButton));
            ussmBtn.Click();
        }
        
        [Given(@"I have selected the Form Type  as '(.*)'")]
        public void GivenIHaveSelectedTheFormTypeAs(string value)
        {

            var formTypeComboBox = currentWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.formTypeComboBox));

            formTypeComboBox.Select(value);
        }
        
        [Given(@"I have selected the mapping type as '(.*)'")]
        public void GivenIHaveSelectedTheMappingTypeAs(string value)
        {
            var mappingComboBox = currentWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.mappingComboBox));
            mappingComboBox.Select(value);
        }
        
        [When(@"I have clicked on Search button")]
        public void WhenIHaveClickedOnSearchButton()
        {
            var searchBtn = currentWindow.Get<Button>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.searchButton));
            searchBtn.Click();
        }
        
        [Then(@"Mapped records should  display")]
        public void ThenMappedRecordsShouldDisplay()
        {
            var selectRecord1 = currentWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.rowSelectionGridView));
            int count = selectRecord1.Rows.Count;


            for (int i = 0; i < count; i++)
            {


                mappedCellValue = selectRecord1.Rows[i].Cells[2].Value.ToString();

                Console.WriteLine(mappedCellValue);

                if (mappedCellValue.Equals("Orion"))
                {

                    break;
                }



            }

            Assert.AreEqual(mappedCellValue, "Orion");
        }
    }
}
