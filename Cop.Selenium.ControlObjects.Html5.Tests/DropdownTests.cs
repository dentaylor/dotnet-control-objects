using System;
using System.Linq;

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
    public void CanGetOptions()
    {
        // Arrange
        // Act
        // Assert
        CollectionAssert.AreEqual(_options, ControlObjectOld.Options);
    }

    [TestMethod]
    public void CanGetSelected()
    {
        // Arrange
        var currentValue = _options.First();

        SetViaJs(currentValue);

        // Act
        // Assert
        Assert.AreEqual(currentValue, ControlObjectOld.Selected);
    }

    [TestMethod]
    public void SelectingInvalidOptionThrows()
    {
        // Arrange
        var toSelect = "Invalid Option";

        // Act & Assert
        Assert.ThrowsExactly<ArgumentException>(() => ControlObjectOld.Select(toSelect));
    }

    [TestMethod]
    public void CanGetSelectedWhenNoneSelected()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(DefaultSelectedOption, ControlObjectOld.Selected);
    }

    [TestMethod]
    public void CanGetSelectedWhenOptionSelected()
    {
        // Arrange
        var toSelect = _options.Skip(1).First();

        SetViaJs(toSelect);

        // Act
        // Assert
        Assert.AreEqual(toSelect, ControlObjectOld.Selected);
    }

    [TestMethod]
    public void CanSelectAlreadySelectedOption()
    {
        // Arrange
        var toSelect = _options.First();

        SetViaJs(toSelect);

        // Act
        ControlObjectOld.Select(toSelect);

        // Assert
        Assert.AreEqual(toSelect, ControlObjectOld.Selected);
    }

    [TestMethod]
    [DataRow(null)]
    [DataRow("")]
    public void SelectingNullOrEmptyDoesNothing(string text)
    {
        // Arrange
        var initialSelected = ControlObjectOld.Selected;

        // Act
        ControlObjectOld.Select(text);

        // Assert
        Assert.AreEqual(initialSelected, ControlObjectOld.Selected);
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
