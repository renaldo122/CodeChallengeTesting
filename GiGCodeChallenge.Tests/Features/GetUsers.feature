@UsersSteps
Feature: Get Users
	As a client
	I want the ability to get a list of users.

@AcceptanceCriteria
Scenario: A client successfully gets list of users
	Given I have a GET API End Point 'api/users'
	When the client makes a get request
	Then I expect response status code '200'
	And  Then I verify json response data to have list of users 


	#Examples: 
	#| id | email                  | first_name | last_name | avatar |
	#| 1  | george.bluth@reqres.in | George     | Bluth     s| https://s3.amazonaws.com/uifaces/faces/twitter/calebogden/128.jpg |