using OpenQA.Selenium;
using FluentAssertions;

namespace selenium_control_extensions_tests
{
    [TestClass]
    public class TextboxTests : TestBase
    {
        private Textbox _ce;

        [TestInitialize]
        public void SetupTest()
        {
            Setup();

            Driver.Navigate().GoToUrl("http://localhost:53433/controls/textbox");
            var element = Driver.FindElement(By.CssSelector("#username"));
            _ce = new Textbox(element);
        }

        [TestMethod]
        public void CanSetTheGetText()
        {
            // Arrange
            var text = "dsds";

            // Act
            _ce.Set(text);
            var result = _ce.Text;

            // Assert
            result.Should().Be(text);
        }
    }
}
