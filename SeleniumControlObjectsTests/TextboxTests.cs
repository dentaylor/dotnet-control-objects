using OpenQA.Selenium;
using SeleniumControlObjects;

namespace SeleniumControlObjectTests
{
    [TestClass]
    public class TextboxTests : TestBase<Textbox>
    {
        [TestInitialize]
        public void SetupTest()
        {
            Setup("textbox", By.CssSelector("#username"));
        }

        [TestMethod]
        public void CanSetThenGetText()
        {
            // Arrange
            var text = "dsds";

            // Act
            ControlObject.Set(text);
            var result = ControlObject.Text;

            // Assert
            Assert.AreEqual(text, result);
        }
    }
}
