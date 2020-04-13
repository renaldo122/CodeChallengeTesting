@UnsuccessfulSteps
Feature: Unsuccessful Registration
	As a client
	I had a unsuccessful register.

@AcceptanceCriteria
Scenario: A client unsuccessful registers
	Given I have a POST API End Point 'api/register'
	When the client makes a POST request with the following data email eve.holt@reqres.in
	Then I expect response status code '400' 
	Then I verify json response body to have an error message

	#Examples: 
	#	|{ "error": "Missing password" }|

