using NUnit.Framework;
using OpenQA.Selenium;
using SWT_Automation;
using TechTalk.SpecFlow;

namespace YourNamespace.Steps
{
    [Binding]
    public class LoginTest
    {
        private string username;
        private string password;

        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverUtility.Initialize(); // Khởi tạo WebDriver trước khi mỗi kịch bản bắt đầu
        }


        [Given(@"the user navigates to the login page")]
        public void SetUp()
        {
            WebDriverUtility.GetDriver().Navigate().GoToUrl("https://fuoverflow.com/login");
        }

        [Given(@"the user has valid credentials from file ""(.*)""")]
        public void ImportAccount(string filePath)
        {
            var credentials = ExcelReader.ReadExcel(filePath);
            foreach (var credential in credentials)
            {
                username = credential[0].ToString();
                password = credential[1].ToString();
            }
        }

        [When(@"the user enters valid credentials")]
        public void Login()
        {
            var usernameField = WebDriverUtility.GetDriver().FindElement(By.Name("login"));
            var passwordField = WebDriverUtility.GetDriver().FindElement(By.Name("password"));

            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
        }

        [When(@"the user submits the login form")]
        public void Submit()
        {
            var loginButton = WebDriverUtility.GetDriver().FindElement(By.XPath("//span[contains(text(),'Đăng nhập')]"));
            loginButton.Click();
        }

        [Then(@"the user should be redirected to the homepage")]
        public void HomePage()
        {
            var currentUrl = WebDriverUtility.GetDriver().Url;
            Assert.AreEqual("https://fuoverflow.com/", currentUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverUtility.QuitDriver(); // Dọn dẹp WebDriver sau khi kết thúc mỗi kịch bản
        }
    }
}
