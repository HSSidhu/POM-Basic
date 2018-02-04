# Created by Harwinder at 02/02/2018
Feature: Hotel booking Regression scripts

  Scenario Outline: 1Enter booking
    Given we are able to access the url
    When I am able to save the details <First_Name> <Surname> <Price> <deppaid>
    Then Application works fine

    Examples: Book In
      | First_Name | Surname | Price | deppaid |
      | Test1      | User    | 120   | Yes     |

Scenario Outline: 2Delete Booking
	Given we are able to access the url
	And I am able to delete specific bookings <First_Name> <Surname> <Price>
	Then Application works fine

	Examples: Remove
	| First_Name | Surname | Price |
	| Test1      | User    | 120   | 

