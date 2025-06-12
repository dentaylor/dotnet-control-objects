using System.Threading.Tasks;

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
    public async Task ClickButtonAsync()
    {
        // Arrange
        // Act
        await ControlObject.ClickAsync();

        // Assert
        var text = Driver.FindElement(By.CssSelector(".alert")).Text;
        Assert.AreEqual("You clicked the button!", text);
    }
}