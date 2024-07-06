using OpenQA.Selenium;
using TechTalk.SpecFlow;
using YourNamespace.Steps;

namespace SWT_Automation.Tests
{
    [Binding]
    public class PostTest
    {
        private readonly LoginTest _loginTest;


        public PostTest(LoginTest loginTest)
        {
            _loginTest = loginTest;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            WebDriverUtility.Initialize(); // Khởi tạo WebDriver trước khi mỗi kịch bản bắt đầu
        }

        [Given(@"the user has logged in")]
        public void GivenTheUserHasLoggedIn()
        {
            _loginTest.SetUp();
            _loginTest.ImportAccount("Info.xlsx");
            _loginTest.Login();
            _loginTest.Submit();
        }

        [When(@"the user navigates to the post page")]
        public void NavigatePostPage()
        {
            WebDriverUtility.GetDriver().Navigate().GoToUrl("https://fuoverflow.com/forums/SWT301/post-thread");
        }

        [When(@"fills out the post form")]
        public void FillForm()
        {
            var titleField = WebDriverUtility.GetDriver().FindElement(By.XPath("//textarea[@id='title']"));
            var contentField = WebDriverUtility.GetDriver().FindElement(By.XPath("//div[@class='fr-element fr-view fr-element-scroll-visible']//p"));

            titleField.SendKeys("SWT301");
            contentField.SendKeys("This is SWT301");
        }

        [When(@"submits the post form")]
        public void WhenSubmitsThePostForm()
        {
            var submit = WebDriverUtility.GetDriver().FindElement(By.XPath(" //button[@class='button--primary button button--icon button--icon--write rippleButton']"));
            submit.Click();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            WebDriverUtility.QuitDriver(); // Dọn dẹp WebDriver sau khi kết thúc mỗi kịch bản
        }


    }
}
