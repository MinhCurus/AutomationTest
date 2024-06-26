using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace YourNamespace.Steps
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;

        [Given(@"the user navigates to the login page")]
        public void GivenTheUserNavigatesToTheLoginPage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://fuoverflow.com/login/");
        }

        [When(@"the user enters valid credentials")]
        public void WhenTheUserEntersValidCredentials()
        {
            var usernameField = driver.FindElement(By.Name("login"));
            var passwordField = driver.FindElement(By.Name("password"));

            usernameField.SendKeys("lmao");
            passwordField.SendKeys("1l0v3G@CH@");
        }

        [When(@"the user submits the login form")]
        public void WhenTheUserSubmitsTheLoginForm()
        {
            var loginButton = driver.FindElement(By.XPath("//span[contains(text(),'Đăng nhập')]"));
            loginButton.Click();
        }

        [Then(@"the user should be redirected to the homepage")]
        public void ThenTheUserShouldBeRedirectedToTheHomepage()
        {
            var currentUrl = driver.Url;
            Assert.AreEqual("https://fuoverflow.com/", currentUrl);
            driver.Quit();
        }
    }
}
