using OpenQA.Selenium;
using SeleniumControlObjects;

namespace SeleniumControlObjectsTests
{
    [TestClass]
    public class ButtonTests : TestBase<Button>
    {
        [TestInitialize]
        public void Setup()
        {
            Setup("button", By.CssSelector("#submit-btn"));
        }

        [TestMethod]
        public void ClickButton()
        {
            // Arrange
            // Act
            ControlObject.Click();

            // Assert
            var text = Driver.FindElement(By.CssSelector(".alert")).Text;
            Assert.Equals(text, " You clicked the button! ");
        }
    }
}