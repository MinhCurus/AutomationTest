Feature: User login

  Scenario: Successful login with valid credentials
    Given the user navigates to the login page
    When the user enters valid credentials
    And the user submits the login form
    Then the user should be redirected to the homepage