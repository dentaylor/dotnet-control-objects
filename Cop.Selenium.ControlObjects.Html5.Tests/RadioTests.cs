using System.Threading.Tasks;

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
    public async Task Set_True_SelectsRadioButtonAsync()
    {
        // Arrange
        // Act
        await ControlObject.ClickAsync();

        // Assert
        Assert.IsTrue(await ControlObject.IsSetAsync());
    }

    [TestMethod]
    public async Task IsSet_ReturnsFalse_WhenRadioButtonNotSelectedAsync()
    {
        // Arrange
        var defaultState = false;

        // Act      
        // Assert
        Assert.AreEqual(defaultState, await ControlObject.IsSetAsync());
    }
}