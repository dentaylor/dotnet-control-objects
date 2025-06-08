namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class RadioTests : TestBase<Radio>
{
    protected override By Locator => By.Id("Red");

    [TestInitialize]
    public void Init()
    {
        LaunchAndNavigateToPage("radio");
    }

    [TestMethod]
    public void Set_True_SelectsRadioButton()
    {
        // Arrange
        // Act
        ControlObject.Click();

        // Assert
        Assert.IsTrue(ControlObject.IsSet);
    }

    [TestMethod]
    public void IsSet_ReturnsFalse_WhenRadioButtonNotSelected()
    {
        // Arrange
        var defaultState = false;

        // Act      
        // Assert
        Assert.AreEqual(defaultState, ControlObject.IsSet);
    }
}