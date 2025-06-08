namespace SeleniumControlObjectTests;

[TestClass]
public class ButtonTests : TestBase<Button>
{
    [TestInitialize]
    public void Setup()
    {
        Setup("button", By.CssSelector("button"));
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