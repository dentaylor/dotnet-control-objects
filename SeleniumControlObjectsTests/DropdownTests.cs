using OpenQA.Selenium;
using SeleniumControlObjects;

namespace SeleniumControlObjectsTests
{
    [TestClass]
    public class DropdownTests : TestBase<Dropdown>
    {
        private readonly List<string> _options = new List<string> { "Option A", "Option B", "Option C" };

        [TestInitialize]
        public void SetupTest()
        {
            Setup("dropdown", By.CssSelector("#dropdown"));
        }

        [TestMethod]
        public void CanGetOptions()
        {
            // Arrange
            // Act
            var result = ControlObject.Options;

            // Assert
            Assert.AreEqual(_options, result);
        }

        [TestMethod]
        public void CanSelectThenGetSelected()
        {
            // Arrange
            var toSelect = _options.Skip(1).First();

            // Act
            ControlObject.Select(toSelect);
            var selected = ControlObject.Selected;

            // Assert
            Assert.AreEqual(toSelect, selected);
        }
    }
}
