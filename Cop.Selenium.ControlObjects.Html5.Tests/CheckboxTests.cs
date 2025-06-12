namespace Cop.Selenium.ControlObjects.Html5.Tests;

[TestClass]
public class CheckboxTests : TestBase<Checkbox>
{
    protected override By Locator => By.CssSelector("input[type='checkbox']");

    [TestInitialize]
    public void Setup()
    {
        LaunchAndNavigateToPage("checkbox");
    }

    [TestMethod]
    public void Toggles_When_Set_True()
    {
        // Arrange
        var isChecked = true;

        // Act
        ControlObjectOld.Set(isChecked);

        // Assert
        Assert.AreEqual(isChecked, ControlObjectOld.IsChecked);
    }

    [TestMethod]
    public void Toggles_When_Set_False()
    {
        // Arrange
        var isChecked = false;
        var initialIsChecked = true;

        SetCheckboxState(initialIsChecked);

        // Act
        ControlObjectOld.Set(isChecked);

        // Assert
        Assert.AreEqual(isChecked, ControlObjectOld.IsChecked);
    }

    [TestMethod]
    public void NoOp_When_Null()
    {
        // Arrange
        bool? isChecked = null;
        var initialIsChecked = true;

        SetCheckboxState(initialIsChecked);

        // Act
        ControlObjectOld.Set(isChecked);

        // Assert
        Assert.AreEqual(initialIsChecked, ControlObjectOld.IsChecked);
    }

    private void SetCheckboxState(bool isChecked)
    {
        ExecuteScript($"arguments[0].checked = {isChecked.ToString().ToLower()};", Driver.FindElement(Locator));
    }
}