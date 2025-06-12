using System;

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
    public void Value_ReturnsCurrentValue()
    {
        // Arrange
        var anyValue = 62;

        SetValue(anyValue);

        // Act
        // Assert
        Assert.AreEqual(ControlObjectOld.Value, anyValue, "Meter value should be the default value.");
    }

    [TestMethod]
    public void GetMin_ReturnsMinValue()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultMin, ControlObjectOld.Min, "Meter min should be the default value.");
    }

    [TestMethod]
    public void GetMax_ReturnsMaxValue()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultMax, ControlObjectOld.Max, "Meter max should be the default value.");
    }

    [TestMethod]
    public void GetOptimum_ReturnsOptimumValue()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultOptimum, ControlObjectOld.Optimum, "Meter optimum should be the default value.");
    }

    [TestMethod]
    public void GetLow_ReturnsLowValue()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultLow, ControlObjectOld.Low, "Meter low should be the default value.");
    }

    [TestMethod]
    public void GetHigh_ReturnsHighValue()
    {
        // Arrange
        // Act
        // Assert
        Assert.AreEqual(defaultHigh, ControlObjectOld.High, "Meter high should be the default value.");
    }

    [TestMethod]
    public void Null_HighValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("high");

        // Act & Assert
        Assert.ThrowsExactly<InvalidOperationException>(() => { var _ = ControlObjectOld.High; });
    }

    [TestMethod]
    public void Null_LowValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("low");

        // Act & Assert
        Assert.ThrowsExactly<InvalidOperationException>(() => { var _ = ControlObjectOld.Low; });
    }

    public void Null_OptimumValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("optimum");

        // Act & Assert
        Assert.ThrowsExactly<InvalidOperationException>(() => { var _ = ControlObjectOld.Optimum; });
    }

    [TestMethod]
    public void Null_MinValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("min");

        // Act & Assert
        Assert.ThrowsExactly<InvalidOperationException>(() => { var _ = ControlObjectOld.Min; });
    }

    [TestMethod]
    public void Null_MaxValue_ThrowsException()
    {
        // Arrange
        RemoveAttribute("max");

        // Act & Assert
        Assert.ThrowsExactly<InvalidOperationException>(() => { var _ = ControlObjectOld.Max; });
    }

    [TestMethod]
    public void Null_Value_ThrowsException()
    {
        // Arrange
        RemoveAttribute("value");

        // Act & Assert
        Assert.ThrowsExactly<InvalidOperationException>(() => { var _ = ControlObjectOld.Value; });
    }
}
