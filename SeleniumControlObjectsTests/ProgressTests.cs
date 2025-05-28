using OpenQA.Selenium;
using SeleniumControlObjectsTests;
using SeleniumControlObjects;

[TestClass]
public class ProgressTests : TestBase<Progress>
{
    [TestInitialize]
    public void Init()
    {
        Setup("progress-test", By.Id("upload-progress"));
    }

    [TestMethod]
    public void Value_ReturnsCurrentProgressValue()
    {
        // Arrange
        var progress = ControlObject;

        // Act
        var value = progress.Value;

        // Assert
        Assert.AreEqual(45, value, "Progress value should be 45.");
    }

    [TestMethod]
    public void Max_ReturnsMaximumProgressValue()
    {
        // Arrange
        var progress = ControlObject;

        // Act
        var max = progress.Max;

        // Assert
        Assert.AreEqual(100, max, "Progress max should be 100.");
    }
}
