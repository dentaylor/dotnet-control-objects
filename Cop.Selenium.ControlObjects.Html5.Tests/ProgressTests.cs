using System;
using System.Threading.Tasks;

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
    public async Task Value_ReturnsCurrentProgressValueAsync()
    {
        // Arrange
        var anyValue = 67;

        SetValue(anyValue);

        // Act
        var value = await ControlObject.GetValueAsync();

        // Assert
        Assert.AreEqual(anyValue, value, "Progress value should be the default value.");
    }

    [TestMethod]
    public async Task Max_ReturnsMaxProgressValueAsync()
    {
        // Arrange
        var maxValue = 100;

        // Act
        // Assert
        Assert.AreEqual(maxValue, await ControlObject.GetMaxAsync());
    }

    [TestMethod]
    public void Null_Value_ThrowsInvalidOperationException()
    {
        // Arrange
        RemoveAttribute("value");

        // Act & Assert
        Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => { var _ = await ControlObject.GetValueAsync(); });
    }

    [TestMethod]
    public void Null_Max_ThrowsInvalidOperationException()
    {
        // Arrange
        RemoveAttribute("max");

        // Act & Assert
        Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => { var _ = await ControlObject.GetMaxAsync(); });
    }
}