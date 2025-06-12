namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class TextareaTests : TestBase<Textarea>
{
    protected override By Locator => By.Id("Message");

    [TestInitialize]
    public void Init()
    {
        LaunchAndNavigateToPage("textarea");
    }

    [TestMethod]
    public void Set_ChangesTextareaValue()
    {
        // Arrange
        var text = "Multiline\r\nText";

        // Act
        ControlObjectOld.Set(text);

        // Assert
        Assert.AreEqual(text, ControlObjectOld.Text);
    }

    [TestMethod]
    public void Value_ReturnsCurrentText()
    {
        // Arrange
        var text = "Multiline\r\nText";

        SetTextareaValue(text);

        // Act
        var value = ControlObjectOld.Text;

        // Assert
        Assert.AreEqual(text, value);
    }

    private void SetTextareaValue(string text)
    {
        ExecuteScript("arguments[0].value = arguments[1];", Driver.FindElement(Locator), text);
    }
}