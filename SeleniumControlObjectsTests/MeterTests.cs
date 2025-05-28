using OpenQA.Selenium;
using SeleniumControlObjects;
using SeleniumControlObjectsTests;

[TestClass]
public class MeterTests : TestBase<Meter>
{
    [TestInitialize]
    public void Init()
    {
        Setup("meter-test", By.Id("disk-usage"));
    }

    [TestMethod]
    public void Value_ReturnsCurrentValue()
    {
        // Arrange
        var meter = ControlObject;

        // Act
        var value = meter.Value;

        // Assert
        Assert.AreEqual(72, value, "Meter value should be 72.");
    }

    [TestMethod]
    public void Min_ReturnsMinValue()
    {
        // Arrange
        var meter = ControlObject;

        // Act
        var min = meter.Min;

        // Assert
        Assert.AreEqual(0, min, "Meter min should be 0.");
    }

    [TestMethod]
    public void Max_ReturnsMaxValue()
    {
        // Arrange
        var meter = ControlObject;

        // Act
        var max = meter.Max;

        // Assert
        Assert.AreEqual(100, max, "Meter max should be 100.");
    }
}


