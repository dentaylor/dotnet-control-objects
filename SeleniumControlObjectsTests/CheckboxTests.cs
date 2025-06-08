namespace SeleniumControlObjectTests;

[TestClass]
public class CheckboxTests : TestBase<Checkbox>
{
    [TestInitialize]
    public void Setup()
    {
        Setup("checkbox", By.CssSelector("input[type='checkbox']"));
    }

    [TestMethod]
    public void Toggles_When_Set_True()
    {
        // Arrange
        var isChecked = true;

        // Act
        ControlObject.Set(isChecked);

        // Assert
        Assert.AreEqual(isChecked, ControlObject.IsChecked);
    }

    [TestMethod]
    public void Toggles_When_Set_False()
    {
        // Arrange
        var isChecked = false;
        var initialIsChecked = true;

        SetCheckboxState(initialIsChecked);

        // Act
        ControlObject.Set(isChecked);

        // Assert
        Assert.AreEqual(isChecked, ControlObject.IsChecked);
    }

    [TestMethod]
    public void NoOp_When_Null()
    {
        // Arrange
        bool? isChecked = null;
        var initialIsChecked = true;

        SetCheckboxState(initialIsChecked);

        // Act
        ControlObject.Set(isChecked);

        // Assert
        Assert.AreEqual(initialIsChecked, ControlObject.IsChecked);
    }

    private void SetCheckboxState(bool isChecked)
    {
        ExecuteScript($"arguments[0].checked = {isChecked.ToString().ToLower()};", Driver.FindElement(Locator));
    }
}