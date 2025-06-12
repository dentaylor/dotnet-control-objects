using System.Threading.Tasks;

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
    public async Task CanSetTextAsync()
    {
        // Arrange
        var text = "some text";

        // Act
        await ControlObject.SetAsync(text);

        // Assert
        Assert.AreEqual(text, await ControlObject.GetTextAsync());
    }

    [TestMethod]
    public async Task CanGetTextAsync()
    {
        // Arrange
        var text = "some text";

        SetTextValue(text);

        // Act
        var result = await ControlObject.GetTextAsync();

        // Assert
        Assert.AreEqual(text, result);
    }

    [TestMethod]
    public async Task Clears_Before_SettingTextAsync()
    {
        // Arrange
        var oldText = "some text";
        var text = "new text";

        SetTextValue(oldText);

        // Act
        await ControlObject.SetAsync(text);

        // Assert
        Assert.AreEqual(text, await ControlObject.GetTextAsync());
    }

    private void SetTextValue(string text)
    {
        ExecuteScript($"document.getElementById('username').value = '{text}';");
    }
}
