Feature: Register a happy mood
	In order to register a happy mood
	As a happy RedMood user
	I want to be able to click a happy smiley icon in a web page

@mytag
Scenario: Register a happy smiley click
	Given I have entered the RedMood application
	And I feel happy
	And the counter for the happy smiley is set to a value
	When I press the happy smiley icon
	Then the happy smiley counter value should be increased with 1 
