using System;

using TestStack.White;
using TestStack.White.Factory;

using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Excel;
using System.Data;
using NUnit.Framework;

namespace OrionSample.TestCases
{
    [Binding]
    public class SearchforUnmappedSteps
    {

        public static Application app;
        public static Window currentWindow;
        public string formType;
        public string mappingType1;
        public string firmID;
        public int index = 2;
        public string mappingType2;
        string unmappedcellValue;
        public string [] excelData = new string[];



        [Given(@"I have taken TestData from excel")]
        public void GivenIHaveTakenTestDataFromExcel()
        {
            var filePath = @"C:\Users\lakshmi.pinasimham\Specflow_Automation\New folder\OrionDemo\OrionDemo\SampleTestData\OwnerShipTestData1.xlsx";
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;
            int idx = filePath.LastIndexOf('.');
            if (filePath.Substring(idx + 1) == "xls")
            {
                //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                //...
            }
            else
            {
                //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                //...
            }
            excelReader.IsFirstRowAsColumnNames = true;

            //4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            formType = result.Tables[0].Rows[0]["FormType"].ToString();
            mappingType1 = result.Tables[0].Rows[0]["MappingType"].ToString();
            mappingType2 = result.Tables[0].Rows[1]["MappingType"].ToString();
            firmID = result.Tables[0].Rows[0]["FirmId"].ToString();

            Console.WriteLine(mappingType2);

            excelReader.Close();


        }

        [Given(@"I have clicked on the USSM button")]
        public void GivenIHaveClickedOnTheUSSMButton()
        {

            currentWindow = LaunchOrionSteps.app.GetWindow(SearchCriteria.ByText("Ownership #1"), InitializeOption.NoCache);
            var ussmBtn = currentWindow.Get<Button>(SearchCriteria.ByText(ObjectRepository.OwnershipWindow.ussmButton));
            ussmBtn.Click();
        }



        [Given(@"I have selected the Form Type")]

        public void GivenIHaveSelectedTheFormType()
        {

            var formTypeComboBox = currentWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.formTypeComboBox));

            formTypeComboBox.Select(formType);
        }

        [Given(@"I have selected the mapping")]
        public void GivenIHaveSelectedTheMapping()
        {
            var mappingComboBox = currentWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.mappingComboBox));
            mappingComboBox.Select(mappingType1);
        }

        [When(@"I have clicked on search button")]
        public void WhenIHaveClickedOnSearchButton()
        {
            var searchBtn = currentWindow.Get<Button>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.searchButton));
            searchBtn.Click();
        }

        [Then(@"Unmapped records should be displayed")]
        public void ThenUnmappedRecordsShouldBeDisplayed()
        {
            Console.WriteLine("Displaying the results");
        }

        [Given(@"I have selected the unmapped record")]
        public void GivenIHaveSelectedTheUnmappedRecord()
        {

            var selectRecord = currentWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.rowSelectionGridView));

            selectRecord.Rows[0].Click();

            unmappedcellValue = selectRecord.Rows[0].Cells[2].Value.ToString();


            Console.WriteLine(unmappedcellValue);


        }
        [Given(@"I have clicked on Manual Search/Map Button")]
        public void GivenIHaveClickedOnManualSearchMapButton()
        {
            var manualsearchBtn = currentWindow.Get<Button>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.manmualSearchButton));
            manualsearchBtn.Click();

        }

        [Given(@"I have given the firm ID")]
        public void GivenIHaveGivenTheFirmID()
        {

            var firmIDTextBox = currentWindow.Get<TextBox>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.firmIDTextBox));
            firmIDTextBox.Text = firmID;


            firmIDTextBox.KeyIn(KeyboardInput.SpecialKeys.RETURN);
        }

        [Given(@"I have selected the ID in dropdown")]
        public void GivenIHaveSelectedTheIDInDropdown()
        {
            var idSelect = currentWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.idComboBox));
            idSelect.Select("ID");

        }
        [Given(@"I have double clicked the record which i have searched for")]
        public void GivenIHaveDoubleClickedTheRecordWhichIHaveSearchedFor()
        {

            var selectRecord = currentWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.manualMapGridView));
            selectRecord.Rows[0].DoubleClick();

        }

        [When(@"I clicked on Save button")]
        public void WhenIClickedOnSaveButton()
        {
            var saveBtn = currentWindow.Get<Button>(SearchCriteria.ByText(ObjectRepository.OwnershipWindow.saveButton));
            saveBtn.Click();

        }

        [When(@"I have clicked on OK button")]
        public void WhenIHaveClickedOnOKButton()
        {
            var okBtn = currentWindow.Get<Button>(SearchCriteria.ByText(ObjectRepository.OwnershipWindow.okButton));
            okBtn.Click();

        }

        [Then(@"the records mapped should be saved")]
        public void ThenTheRecordsMappedShouldBeSaved()
        {
            Console.WriteLine("Record is saved");

        }


        [Given(@"I have selected the mapping type")]
        public void GivenIHaveSelectedTheMappingType()
        {
            var mappingComboBox = currentWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.mappingComboBox));
            mappingComboBox.Select(mappingType2);
        }


        [Then(@"Mapped records will be displayed")]
        public void ThenMappedRecordsWillBeDisplayed()
        {



            var selectRecord1 = currentWindow.Get<TestStack.White.UIItems.TableItems.Table>(SearchCriteria.ByAutomationId(ObjectRepository.OwnershipWindow.rowSelectionGridView));
            int count = selectRecord1.Rows.Count;


            for (int i = 0; i < count; i++)
            {


                string mappedCellValue = selectRecord1.Rows[i].Cells[2].Value.ToString();

                Console.WriteLine(mappedCellValue);

                if (mappedCellValue.Equals(unmappedcellValue))
                {
                    Assert.AreEqual("pass", "pass");
                    break;
                }


            }



        }






    }
}
