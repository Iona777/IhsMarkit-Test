Feature: IHS dotNotFiddle page
	In order to test the dotNetFiddle page
	As a user
	I want the outcome associated with my name


Scenario Outline: Test1: Click Run Button
	Given that I click on the Run button
	Then the text "<Expected Text>" is displayed
Examples: 
| Expected Text	|
| "Hello World" |


Scenario Outline: Test2: Perform actions based on name
	Given user name is "<Name>" I take the action for that name
	Then I get outcome for "<Name>"
Examples: 
| Name    |
| Alison  |
| Greg    |
| Mukesh  |
| Rebecca |
| William |


