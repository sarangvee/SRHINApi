Feature: API Testing for SRHIN

A short summary of the feature

@tag1
Scenario: API Testing Scenario 1
	Given load the URL "https://schoolmgmtapi-cinddev-hha5fjhxawd2hpdw.centralindia-01.azurewebsites.net/api/v1/Admin/Subscription"
	Then verify the response status code is 200
	


@tag2	
Scenario: API Testing Scenario 2
	Given load the URL "https://schoolmgmtapi-cinddev-hha5fjhxawd2hpdw.centralindia-01.azurewebsites.net/api/v1/school/Exam"
	Then verify the response status code is 200

