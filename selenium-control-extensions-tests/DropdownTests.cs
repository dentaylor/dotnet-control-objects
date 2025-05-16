using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_control_extensions_tests
{
    [TestClass]
    public class DropdownTests
    {
        private ChromeDriver _driver;
        private Dropdown _ce;
        private readonly string[] _options = new[] { "Option A", "Option B", "Option C" };

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://localhost:53433/controls/dropdown");
            var element = _driver.FindElement(By.CssSelector("#dropdown"));
            _ce = new Dropdown(element);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver?.Quit();
        }

        [TestMethod]
        public void CanGetOptions()
        {
            // Arrange
            // Act
            var result = _ce.Options;

            // Assert
            result.Should().BeEquivalentTo(_options);
        }

        [TestMethod]
        public void CanSelectThenGetSelected()
        {
            // Arrange
            var toSelect = _options.Skip(1).First();

            // Act
            _ce.Select(toSelect);
            var selected = _ce.Selected;

            // Assert
            selected.Should().Be(toSelect);
        }
    }
}
