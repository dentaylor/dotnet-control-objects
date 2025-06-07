using OpenQA.Selenium;
using SeleniumControlObjects;

namespace SeleniumControlObjectTests
{
    [TestClass]
    public class CheckboxTests : TestBase<Checkbox>
    {
        [TestInitialize]
        public void Setup()
        {
            Setup("checkbox", By.CssSelector("#accept-terms"));
        }

        [TestMethod]
        public void Checkbox_Check_SetsCheckedState()
        {
            // Arrange
            // Act
            ControlObject.Set(true);
            var isChecked = ControlObject.IsChecked;

            // Assert
            Assert.IsTrue(isChecked);
        }

        [TestMethod]
        public void Checkbox_Set_False()
        {
            // Arrange
            Checkbox_Check_SetsCheckedState();

            // Act
            ControlObject.Set(false);
            var isChecked = ControlObject.IsChecked;

            // Assert
            Assert.IsFalse(isChecked);
        }

        [TestMethod]
        public void Checkbox_SetFalse_DoesNothingIfSetNull()
        {
            // Arrange
            Checkbox_Check_SetsCheckedState();

            // Act
            ControlObject.Set(null);
            var isChecked = ControlObject.IsChecked;

            // Assert
            Assert.IsTrue(isChecked);
        }
    }
}