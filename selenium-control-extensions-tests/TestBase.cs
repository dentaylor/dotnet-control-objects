using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_control_extensions_tests
{
    public abstract class TestBase
    {
        protected IWebDriver Driver { get; set; }

        protected TestContext TestContext { get; set; }

        [TestInitialize]
        protected void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        protected void Cleanup()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
            {
                Driver?.Quit();
            }
        }
    }
}