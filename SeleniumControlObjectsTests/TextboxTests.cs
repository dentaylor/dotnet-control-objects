namespace SeleniumControlObjectTests;

[TestClass]
public class TextboxTests : TestBase<Textbox>
{
    [TestInitialize]
    public void SetupTest()
    {
        Setup("textbox", By.CssSelector("#username"));
    }

    [TestMethod]
    public void CanSetText()
    {
        // Arrange
        var text = "some text";

        // Act
        ControlObject.Set(text);

        // Assert
        Assert.AreEqual(text, ControlObject.Text);
    }

    [TestMethod]
    public void CanGetText()
    {
        // Arrange
        var text = "some text";

        SetTextValue(text);

        // Act
        var result = ControlObject.Text;

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
        ControlObject.Set(text);
        
        // Assert
        Assert.AreEqual(text, ControlObject.Text);
    }

    private void SetTextValue(string text)
    {
        ExecuteScript($"document.getElementById('username').value = '{text}';");
    }
}
