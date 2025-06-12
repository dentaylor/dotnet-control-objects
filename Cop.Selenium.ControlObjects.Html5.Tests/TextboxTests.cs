namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class TextboxTests : TestBase<Textbox>
{
    protected override By Locator => By.CssSelector("#username");

    [TestInitialize]
    public void SetupTest()
    {
        LaunchAndNavigateToPage("textbox");
    }

    [TestMethod]
    public void CanSetText()
    {
        // Arrange
        var text = "some text";

        // Act
        ControlObjectOld.Set(text);

        // Assert
        Assert.AreEqual(text, ControlObjectOld.Text);
    }

    [TestMethod]
    public void CanGetText()
    {
        // Arrange
        var text = "some text";

        SetTextValue(text);

        // Act
        var result = ControlObjectOld.Text;

        // Assert
        Assert.AreEqual(text, result);
    }

    [TestMethod]
    public void Clears_Before_SettingText()
    {
        // Arrange
        var oldText = "some text";
        var text = "new text";

        SetTextValue(oldText);

        // Act
        ControlObjectOld.Set(text);
        
        // Assert
        Assert.AreEqual(text, ControlObjectOld.Text);
    }

    private void SetTextValue(string text)
    {
        ExecuteScript($"document.getElementById('username').value = '{text}';");
    }
}
