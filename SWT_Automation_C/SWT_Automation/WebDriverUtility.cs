using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SWT_Automation
{
    public static class WebDriverUtility
    {
        private static IWebDriver _webDriver;

        public static void Initialize()
        {
            _webDriver = new ChromeDriver(); // Khởi tạo ChromeDriver, bạn có thể thay đổi tùy theo trình duyệt và cấu hình của bạn
        }

        public static IWebDriver GetDriver()
        {
            if (_webDriver == null)
            {
                Initialize();
            }
            return _webDriver;
        }

        public static void QuitDriver()
        {
            if (_webDriver != null)
            {
                _webDriver.Quit();
                _webDriver = null;
            }
        }
    }
}
