Feature: Register moods
	In order to register a mood
	As a RedMood user
	I want to be able to click a happy smiley or a sad smiley icon in a web page

@mytag
Scenario: Register a happy smiley click
	Given I have entered the RedMood application
	And I feel happy
	And the counter for the happy smiley is set to a value
	When I press the happy smiley icon
	Then the clicked smiley counter value should be increased with 1 


@mytag
Scenario: Register a sad smiley click
	Given I have entered the RedMood application
	And I feel sad
	And the counter for the sad smiley is set to a value
	When I press the sad smiley icon
	Then the clicked smiley counter value should be increased with 1 
