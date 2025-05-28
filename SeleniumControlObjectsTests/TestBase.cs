using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumControlObjectsTests
{
    public abstract class TestBase<TControlObject>
    {
        protected IWebDriver Driver { get; set; }

        protected TestContext TestContext { get; set; }

        protected By Locator { get; set; }

        protected TControlObject ControlObject => (TControlObject)Activator.CreateInstance(typeof(TControlObject), Driver.FindElement(Locator));
    
        [TestInitialize]
        protected void Setup(string page, By locator)
        {
            Locator = locator;

            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://localhost:53433/" + page);
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