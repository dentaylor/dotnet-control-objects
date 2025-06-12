using System.Threading.Tasks;

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
    public async Task Set_ChangesTextareaValueAsync()
    {
        // Arrange
        var text = "Multiline\r\nText";

        // Act
        await ControlObject.SetAsync(text);

        // Assert
        Assert.AreEqual(text, await ControlObject.GetTextAsync());
    }

    [TestMethod]
    public async Task Value_ReturnsCurrentTextAsync()
    {
        // Arrange
        var text = "Multiline\r\nText";

        SetTextareaValue(text);

        // Act
        var value = ControlObject.GetTextAsync();

        // Assert
        Assert.AreEqual(text, await value);
    }

    private void SetTextareaValue(string text)
    {
        ExecuteScript("arguments[0].value = arguments[1];", Driver.FindElement(Locator), text);
    }
}