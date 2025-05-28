using OpenQA.Selenium;
using SeleniumControlObjectsTests;
using SeleniumControlObjects;

[TestClass]
public class RadioTests : TestBase<Radio>
{
    [TestInitialize]
    public void Init()
    {
        Setup("radio-test", By.Id("credit"));
    }

    [TestMethod]
    public void Set_True_SelectsRadioButton()
    {
        // Arrange
        var radio = ControlObject;

        // Act
        radio.Set(true);

        // Assert
        Assert.AreEqual("true", radio.IsSet);
    }

    [TestMethod]
    public void Set_False_DoesNotDeselectRadioButton()
    {
        // Arrange
        var radio = ControlObject;
        radio.Set(true);

        // Act
        radio.Set(false); // should be ignored

        // Assert
        Assert.AreEqual("true", radio.IsSet);
    }

    [TestMethod]
    public void IsSet_ReturnsFalse_WhenRadioIsUnselected()
    {
        // Arrange
        var radio = ControlObject;

        // Act
        var state = radio.IsSet;

        // Assert
        Assert.AreEqual("false", state);
    }
}



