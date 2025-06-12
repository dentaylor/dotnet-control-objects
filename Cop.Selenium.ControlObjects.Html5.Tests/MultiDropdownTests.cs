using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class MultiDropdownTests : TestBase<MultiDropdown>
{
    private readonly IEnumerable<string> DefaultOptions =
    [
        "Option 1",
        "Option 2",
        "Option 3",
        "Option 4",
        "Option 5"
    ];

    protected override By Locator => By.Id(ElementId);

    private string ElementId = "SelectedOptions";

    [TestInitialize]
    public void Init()
    {
        LaunchAndNavigateToPage("multidropdown");
    }

    [TestMethod]
    public async Task Select_SelectsMultipleOptionsAsync()
    {
        // Arrange
        var values = DefaultOptions.Take(2).ToArray();

        // Act
        await ControlObject.SelectAsync(values);

        // Assert
        CollectionAssert.AreEquivalent(values, await ControlObject.GetSelectedAsync());
    }

    [TestMethod]
    public async Task Select_Multiple_WhenSomeAlreadyGetSelectedAsync()
    {
        // Arrange
        var initialOptions = DefaultOptions.Skip(2).Take(2);
        var newOptions = DefaultOptions.Take(2).ToArray();
        var allOptions = initialOptions.Concat(newOptions).ToArray();

        SetDropdownValue(initialOptions);

        // Act
        await ControlObject.SelectAsync(newOptions);

        // Assert
        CollectionAssert.AreEquivalent(allOptions, await ControlObject.GetSelectedAsync());
    }

    [TestMethod]
    public async Task GetSelectedAsync()
    {
        // Arrange
        var options = DefaultOptions.Skip(2).Take(2);

        SetDropdownValue(options);

        // Act
        var selected = await ControlObject.GetSelectedAsync();

        // Assert
        CollectionAssert.AreEquivalent(options.ToArray(), selected);
    }

    [TestMethod]
    public async Task Select_AddsToCurrentSelectionAsync()
    {
        // Arrange
        var currentOptions = DefaultOptions.Skip(2).Take(2);
        var options = DefaultOptions.Skip(1).Take(1).ToArray();
        var allOptions = currentOptions.Concat(options).ToArray();

        SetDropdownValue(currentOptions);

        // Act
        await ControlObject.SelectAsync(options);

        // Assert
        CollectionAssert.AreEquivalent(allOptions, await ControlObject.GetSelectedAsync());
    }

    [TestMethod]
    public void Select_OptionNotInDropdown_Throws()
    {
        // Arrange
        var values = new[] { "AnyValue" };

        // Act & Assert
        _ = Assert.ThrowsExactlyAsync<ArgumentException>(() => ControlObject.SelectAsync(values));
    }

    [TestMethod]
    public async Task Can_GetOptions()
    {
        // Arrange
        // Act
        // Assert
        CollectionAssert.AreEquivalent(DefaultOptions.ToArray(), await ControlObject.GetOptionsAsync());
    }

    [TestMethod]
    public async Task Can_GetOptions_WhenNonePresent_ReturnsEmptyCollectionAsync()
    {
        // Arrange  
        ExecuteScript($"document.getElementById('{ElementId}').innerHTML = ''");

        // Act  
        // Assert  
        CollectionAssert.AreEquivalent(Array.Empty<string>(), await ControlObject.GetOptionsAsync());
    }

    [TestMethod]
    public async Task Clear_Deselects_AllAsync()
    {
        // Arrange
        var options = DefaultOptions.Take(2);

        SetDropdownValue(options);

        // Act
        await ControlObject.ClearAsync();

        // Assert
        var selected = await ControlObject.GetSelectedAsync();
        Assert.AreEqual(0, selected.Length);
    }

    private void SetDropdownValue(IEnumerable<string> values)
    {
        var actions = new Actions(Driver);
        actions.KeyDown(Keys.Control);
        foreach (var value in values)
        {
            var option = Driver.FindElement(By.XPath($"//select[@id='{ElementId}']/option[text()='{value}']"));
            actions.Click(option);
        }
        actions.KeyUp(Keys.Control);
        actions.Build().Perform();
    }
}

