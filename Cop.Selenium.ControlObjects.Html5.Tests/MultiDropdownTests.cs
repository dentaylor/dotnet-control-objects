using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;

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

    protected override By Locator => By.Id("SelectedOptions");

    [TestInitialize]
    public void Init()
    {
        LaunchAndNavigateToPage("multidropdown");
    }

    [TestMethod]
    public void Select_SelectsMultipleOptions()
    {
        // Arrange
        var values = DefaultOptions.Take(2).ToArray();

        // Act
        ControlObjectOld.Select(values);

        // Assert
        CollectionAssert.AreEquivalent(values, ControlObjectOld.Selected);
    }

    [TestMethod]
    public void Select_Multiple_WhenSomeAlreadySelected()
    {
        // Arrange
        var initialOptions = DefaultOptions.Skip(2).Take(2);
        var newOptions = DefaultOptions.Take(2).ToArray();
        var allOptions = initialOptions.Concat(newOptions).ToArray();
        
        SetDropdownValue(initialOptions);
        
        // Act
        ControlObjectOld.Select(newOptions);
        
        // Assert
        CollectionAssert.AreEquivalent(allOptions, ControlObjectOld.Selected);
    }

    [TestMethod]
    public void Selected_ReturnsCurrentlySelectedOptions()
    {
        // Arrange
        var options = DefaultOptions.Skip(2).Take(2);

        SetDropdownValue(options);

        // Act
        var selected = ControlObjectOld.Selected;

        // Assert
        CollectionAssert.AreEquivalent(options.ToArray(), selected);
    }

    [TestMethod]
    public void Select_AddsToCurrentSelection()
    {
        // Arrange
        var currentOptions = DefaultOptions.Skip(2).Take(2);
        var options = DefaultOptions.Skip(1).Take(1).ToArray();
        var allOptions = currentOptions.Concat(options).ToArray();

        SetDropdownValue(currentOptions);

        // Act
        ControlObjectOld.Select(options);

        // Assert
        CollectionAssert.AreEquivalent(allOptions, ControlObjectOld.Selected);
    }

    [TestMethod]
    public void Select_OptionNotInDropdown_Throws()
    {
        // Arrange
        var values = new[] { "AnyValue" };

        // Act & Assert
        _ = Assert.ThrowsExactly<ArgumentException>(() => ControlObjectOld.Select(values));
    }

    [TestMethod]
    public void Can_GetOptions()
    {
        // Arrange
        // Act
        // Assert
        CollectionAssert.AreEquivalent(DefaultOptions.ToArray(), ControlObjectOld.Options);
    }

    [TestMethod]
    public void Can_GetOptions_WhenNonePresent_ReturnsEmptyCollection()
    {
        // Arrange  
        ExecuteScript("document.getElementById('SelectedOptions').innerHTML = ''");

        // Act  
        // Assert  
        CollectionAssert.AreEquivalent(Array.Empty<string>(), ControlObjectOld.Options);
    }

    [TestMethod]
    public void Clear_Deselects_All()
    {
        // Arrange
        var options = DefaultOptions.Take(2);

        SetDropdownValue(options);

        // Act
        ControlObjectOld.Clear();

        // Assert
        Assert.IsFalse(ControlObjectOld.Selected.Any());
    }

    private void SetDropdownValue(IEnumerable<string> values)
    {
        var actions = new Actions(Driver);
        actions.KeyDown(Keys.Control);
        foreach (var value in values)
        {
            var option = Driver.FindElement(By.XPath($"//select[@id='SelectedOptions']/option[text()='{value}']"));
            actions.Click(option);
        }
        actions.KeyUp(Keys.Control);
        actions.Build().Perform();
    }
}

