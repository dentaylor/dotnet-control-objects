namespace SeleniumControlObjectTests;

[TestClass]
public class RadioTests : TestBase<Radio>
{
    [TestInitialize]
    public void Init()
    {
        Setup("radio", By.Id("Red"));
    }

    [TestMethod]
    public void Set_True_SelectsRadioButton()
    {
        // Arrange
        // Act
        ControlObject.Click();

        // Assert
        Assert.IsTrue(ControlObject.IsSet);
    }

    [TestMethod]
    public void IsSet_ReturnsFalse_WhenRadioButtonNotSelected()
    {
        // Arrange
        var defaultState = false;

        // Act      
        // Assert
        Assert.AreEqual(defaultState, ControlObject.IsSet);
    }
}