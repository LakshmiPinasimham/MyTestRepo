Feature: SearchforUnmapped
	Search for Unmapped Records

Background: 
Given I have launched Orion App
And I have clicked on Ownership tab 
Then The Ownership tab should be opened

@mytag
Scenario: Search For Unmapped Records to Map
Given I have taken TestData from excel
And I have clicked on the USSM button
And I have selected the Form Type
And  I have selected the mapping
When I have clicked on search button
Then Unmapped records should be displayed
Given I have selected the unmapped record
And I have clicked on Manual Search/Map Button
And I have selected the ID in dropdown
And I have given the firm ID
And I have double clicked the record which i have searched for
When I clicked on Save button
And I have clicked on OK button
Then the records mapped should be saved
#Given I have selected the mapping type
#When I have clicked on search button
#Then Mapped records will be displayed


@mytag
Scenario: To validate the Mapped Records
Given I have clicked on the USSM button in Ownership Window
And I have selected the Form Type  as '424b4'
And I have selected the mapping type as 'Mapping'
When I have clicked on Search button
Then Mapped records should  display














