using System;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class MeterTests : TestBase<Meter>
{
    private readonly double defaultMin = 0;
    private readonly double defaultMax = 100;
    private readonly double defaultLow = 30;
    private readonly double defaultHigh = 70;
    private readonly double defaultOptimum = 80;

    protected override By Locator => By.TagName("meter");

    [TestInitialize]
    public void Init()
    {
        LaunchAndNavigateToPage("meter");
    }

    [TestMethod]
    public async Task Value_ReturnsCurrentValueAsync()
    {
        // Arrange
        var anyValue = 62;

        SetValue(anyValue);

        // Act
        // Assert
        Assert.AreEqual(await ControlObject.GetValueAsync(), anyValue, "Meter value should be the default value.");
    }

    [TestMethod]
    public async Task GetMin_ReturnsMinValueAsync()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultMin, await ControlObject.GetMinAsync(), "Meter min should be the default value.");
    }

    [TestMethod]
    public async Task GetMax_ReturnsMaxValueAsync()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultMax, await ControlObject.GetMaxAsync(), "Meter max should be the default value.");
    }

    [TestMethod]
    public async Task GetOptimum_ReturnsOptimumValueAsync()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultOptimum, await ControlObject.GetOptimumAsync(), "Meter optimum should be the default value.");
    }

    [TestMethod]
    public async Task GetLow_ReturnsLowValueAsync()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultLow, await ControlObject.GetLowAsync(), "Meter low should be the default value.");
    }

    [TestMethod]
    public async Task GetHigh_ReturnsHighValueAsync()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultHigh, await ControlObject.GetHighAsync(), "Meter high should be the default value.");
    }

    [TestMethod]
    public void Null_HighValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("high");

        // Act & Assert
        Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => { var _ = await ControlObject.GetHighAsync(); });
    }

    [TestMethod]
    public void Null_LowValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("low");

        // Act & Assert
        Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => { var _ = await ControlObject.GetLowAsync(); });
    }

    public void Null_OptimumValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("optimum");

        // Act & Assert
        Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => { var _ = await ControlObject.GetOptimumAsync(); });
    }

    [TestMethod]
    public void Null_MinValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("min");

        // Act & Assert
        Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => { var _ = await ControlObject.GetMinAsync(); });
    }

    [TestMethod]
    public void Null_MaxValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("max");

        // Act & Assert
        Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => { var _ = await ControlObject.GetMaxAsync(); });
    }

    [TestMethod]
    public void Null_Value_ThrowsException()
    {
        // Arrange
        RemoveAttribute("value");

        // Act & Assert
        Assert.ThrowsExactlyAsync<InvalidOperationException>(async () => { var _ = await ControlObject.GetValueAsync(); });
    }
}
