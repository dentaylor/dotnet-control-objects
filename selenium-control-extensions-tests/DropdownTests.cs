using FluentAssertions;
using OpenQA.Selenium;

namespace selenium_control_extensions_tests
{
    [TestClass]
    public class DropdownTests : TestBase
    {
        private Dropdown _ce;
        private readonly string[] _options = new[] { "Option A", "Option B", "Option C" };

        [TestInitialize]
        public void SetupTest()
        {
            Setup();

            Driver.Navigate().GoToUrl("http://localhost:53433/controls/dropdown");
            var element = Driver.FindElement(By.CssSelector("#dropdown"));
            _ce = new Dropdown(element);
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
