Feature: Post

Background:
  Given the user has logged in

Scenario: Post a new article after successful login
    When the user navigates to the post page
    And fills out the post form
    And submits the post form