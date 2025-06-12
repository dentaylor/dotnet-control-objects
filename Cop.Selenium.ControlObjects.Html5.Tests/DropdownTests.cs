using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class DropdownTests : TestBase<Dropdown>
{
    protected override By Locator => By.CssSelector("#dropdown");

    private readonly string[] _options =
        [
            "Option A",
            "Option B",
            "Option C"
        ];

    private string DefaultSelectedOption => _options.First();

    [TestInitialize]
    public void SetupTest()
    {
        LaunchAndNavigateToPage("dropdown");
    }

    [TestMethod]
    public async Task CanGetOptionsAsync()
    {
        // Arrange
        // Act
        // Assert
        CollectionAssert.AreEqual(_options, await ControlObject.GetOptionsAsync());
    }

    [TestMethod]
    public async Task CanGetSelectedAsync()
    {
        // Arrange
        var currentValue = _options.First();

        SetViaJs(currentValue);

        // Act
        // Assert
        Assert.AreEqual(currentValue, await ControlObject.GetSelectedAsync());
    }

    [TestMethod]
    public void SelectingInvalidOptionThrows()
    {
        // Arrange
        var toSelect = "Invalid Option";

        // Act & Assert
        Assert.ThrowsExactlyAsync<ArgumentException>(async () => await ControlObject.SelectAsync(toSelect));
    }

    [TestMethod]
    public async Task CanGetSelectedWhenNoneSelectedAsync()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(DefaultSelectedOption, await ControlObject.GetSelectedAsync());
    }

    [TestMethod]
    public async Task CanGetSelectedWhenOptionSelectedAsync()
    {
        // Arrange
        var toSelect = _options.Skip(1).First();

        SetViaJs(toSelect);

        // Act
        // Assert
        Assert.AreEqual(toSelect, await ControlObject.GetSelectedAsync());
    }

    [TestMethod]
    public async Task CanSelectAlreadySelectedOptionAsync()
    {
        // Arrange
        var toSelect = _options.First();

        SetViaJs(toSelect);

        // Act
        await ControlObject.SelectAsync(toSelect);

        // Assert
        Assert.AreEqual(toSelect, await ControlObject.GetSelectedAsync());
    }

    [TestMethod]
    [DataRow(null)]
    [DataRow("")]
    public async Task SelectingNullOrEmptyDoesNothingAsync(string text)
    {
        // Arrange
        var initialSelected = await ControlObject.GetSelectedAsync();

        // Act
        await ControlObject.SelectAsync(text);

        // Assert
        Assert.AreEqual(initialSelected, await ControlObject.GetSelectedAsync());
    }

    private void SetViaJs(string value)
    {
        var script = @"
        var select = arguments[0];
        var value = arguments[1];
        for (var i = 0; i < select.options.length; i++) {
            if (select.options[i].text === value) {
                select.selectedIndex = i;
                select.options[i].selected = true;
                select.dispatchEvent(new Event('change', { bubbles: true }));
                break;
            }
        }";

        ExecuteScript(script, Driver.FindElement(Locator), value);
    }
}
