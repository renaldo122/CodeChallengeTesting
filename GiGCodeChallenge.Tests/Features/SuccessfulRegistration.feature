@RegistrationSteps
Feature: Successful Registration
	As a client
	I want to successfully register.

@AcceptanceCriteria
Scenario: A client successfully registers
	Given I have a POST API End Point 'api/register'
	When the client makes a POST request with the following data email eve.holt@reqres.in and password pistol
	Then I expect response status code '200' 
	Then I verify json response body to have a token 

	#Examples: 
	#	|{ "id": 4, "token": "QpwL5tke4Pnpja7X4" }|

