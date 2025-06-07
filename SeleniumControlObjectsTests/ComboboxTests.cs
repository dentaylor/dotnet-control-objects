using OpenQA.Selenium;
using SeleniumControlObjects;
using System.Threading.Tasks;

namespace SeleniumControlObjectTests
{
    [TestClass]
    public class ComboBoxTests : TestBase<ComboBox>
    {
        [TestInitialize]
        public void Init()
        {
            Setup("combobox-test", By.Id("fruit"));
        }

        [TestMethod]
        public async Task EnterTextAsync_SetsInputValue()
        {
            // Arrange
            var comboBox = ControlObject;

            // Act
            ControlObject.Set("Banana");
            var value = ControlObject.Selected;

            // Assert
            Assert.AreEqual("Banana", value, "ComboBox value should be 'Banana'.");
        }

        [TestMethod]
        public void GetValueAsync_ReturnsCurrentInputValue()
        {
            // Arrange
            ControlObject.Set("Cherry");

            // Act
            var value = ControlObject.Selected;

            // Assert
            Assert.AreEqual("Cherry", value);
        }
    }
}