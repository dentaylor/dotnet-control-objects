using System;

namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class ProgressTests : TestBase<Progress>
{
    protected override By Locator => By.TagName("progress");

    [TestInitialize]
    public void Init()
    {
        LaunchAndNavigateToPage("progress");
    }

    [TestMethod]
    public void Value_ReturnsCurrentProgressValue()
    {
        // Arrange
        var anyValue = 67;

        SetValue(anyValue);

        // Act
        var value = ControlObject.Value;

        // Assert
        Assert.AreEqual(anyValue, value, "Progress value should be the default value.");
    }

    [TestMethod]
    public void Max_ReturnsMaxProgressValue()
    {
        // Arrange
        var maxValue = 100;

        // Act
        // Assert
        Assert.AreEqual(maxValue, ControlObject.Max);
    }

    [TestMethod]
    public void Null_Value_ThrowsInvalidOperationException()
    {
        // Arrange
        RemoveAttribute("value");

        // Act & Assert
        Assert.ThrowsExactly<InvalidOperationException>(() => { var _ = ControlObject.Value; });
    }

    [TestMethod]
    public void Null_Max_ThrowsInvalidOperationException()
    {
        // Arrange
        RemoveAttribute("max");

        // Act & Assert
        Assert.ThrowsExactly<InvalidOperationException>(() => { var _ = ControlObject.Max; });
    }
}