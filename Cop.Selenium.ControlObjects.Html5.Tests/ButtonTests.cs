namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class ButtonTests : TestBase<Button>
{
    protected override By Locator => By.CssSelector("button");

    [TestInitialize]
    public void Setup()
    {
        LaunchAndNavigateToPage("button");
    }

    [TestMethod]
    public void ClickButton()
    {
        // Arrange
        // Act
        ControlObject.Click();

        // Assert
        var text = Driver.FindElement(By.CssSelector(".alert")).Text;
        Assert.AreEqual("You clicked the button!", text);
    }
}