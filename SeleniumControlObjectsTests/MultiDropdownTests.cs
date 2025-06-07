using OpenQA.Selenium;
using SeleniumControlObjects;

namespace SeleniumControlObjectTests
{
    [TestClass]
    public class MultiDropdownTests : TestBase<MultiDropdown>
    {
        [TestInitialize]
        public void Init()
        {
            Setup("multi-dropdown-test", By.Id("colors"));
        }

        [TestMethod]
        public void Select_SelectsMultipleOptions()
        {
            // Arrange
            var dropdown = ControlObject;

            // Act
            dropdown.Select("Red", "Blue");

            // Assert
            var selected = dropdown.Selected;
            Assert.AreEqual(2, selected.Length);
            CollectionAssert.AreEquivalent(new[] { "Red", "Blue" }, selected);
        }

        [TestMethod]
        public void Selected_ReturnsCurrentlySelectedOptions()
        {
            // Arrange
            var dropdown = ControlObject;
            dropdown.Select("Green");

            // Act
            var selected = dropdown.Selected;

            // Assert
            Assert.AreEqual(1, selected.Length);
            Assert.AreEqual("Green", selected[0]);
        }
    }
}

