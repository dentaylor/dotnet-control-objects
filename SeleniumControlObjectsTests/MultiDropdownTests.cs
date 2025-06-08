using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumControlObjectTests;

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

    [TestInitialize]
    public void Init()
    {
        Setup("multidropdown", By.Id("SelectedOptions"));
    }

    [TestMethod]
    public void Select_SelectsMultipleOptions()
    {
        // Arrange
        var values = DefaultOptions.Take(2).ToArray();

        // Act
        ControlObject.Select(values);

        // Assert
        CollectionAssert.AreEquivalent(values, ControlObject.Selected);
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
        ControlObject.Select(newOptions);
        
        // Assert
        CollectionAssert.AreEquivalent(allOptions, ControlObject.Selected);
    }

    [TestMethod]
    public void Selected_ReturnsCurrentlySelectedOptions()
    {
        // Arrange
        var options = DefaultOptions.Skip(2).Take(2);

        SetDropdownValue(options);

        // Act
        var selected = ControlObject.Selected;

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
        ControlObject.Select(options);

        // Assert
        CollectionAssert.AreEquivalent(allOptions, ControlObject.Selected);
    }

    [TestMethod]
    public void Select_OptionNotInDropdown_Throws()
    {
        // Arrange
        var values = new[] { "AnyValue" };

        // Act & Assert
        _ = Assert.ThrowsExactly<ArgumentException>(() => ControlObject.Select(values));
    }

    [TestMethod]
    public void Can_GetOptions()
    {
        // Arrange
        // Act
        // Assert
        CollectionAssert.AreEquivalent(DefaultOptions.ToArray(), ControlObject.Options);
    }

    [TestMethod]
    public void Can_GetOptions_WhenNonePresent_ReturnsEmptyCollection()
    {
        // Arrange  
        ExecuteScript("document.getElementById('SelectedOptions').innerHTML = ''");

        // Act  
        // Assert  
        CollectionAssert.AreEquivalent(Array.Empty<string>(), ControlObject.Options);
    }

    [TestMethod]
    public void Clear_Deselects_All()
    {
        // Arrange
        var options = DefaultOptions.Take(2);

        SetDropdownValue(options);

        // Act
        ControlObject.Clear();

        // Assert
        Assert.IsFalse(ControlObject.Selected.Any());
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

