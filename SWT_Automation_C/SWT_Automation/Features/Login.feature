Feature: User login

Background:
    Given the user navigates to the login page
    And the user has valid credentials from file "Info.xlsx"
    When the user enters valid credentials
    And the user submits the login form

Scenario: Successful Login
    Then the user should be redirected to the homepage
