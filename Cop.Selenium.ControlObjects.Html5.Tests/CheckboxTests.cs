using System.Threading.Tasks;

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
    public async Task Toggles_When_Set_TrueAsync()
    {
        // Arrange
        var isChecked = true;

        // Act
        await ControlObject.SetAsync(isChecked);

        // Assert
        Assert.AreEqual(isChecked, await ControlObject.IsCheckedAsync());
    }

    [TestMethod]
    public async Task Toggles_When_Set_FalseAsync()
    {
        // Arrange
        var isChecked = false;
        var initialIsChecked = true;

        SetCheckboxState(initialIsChecked);

        // Act
        await ControlObject.SetAsync(isChecked);

        // Assert
        Assert.AreEqual(isChecked, await ControlObject.IsCheckedAsync());
    }

    [TestMethod]
    public async Task NoOp_When_NullAsync()
    {
        // Arrange
        bool? isChecked = null;
        var initialIsChecked = true;

        SetCheckboxState(initialIsChecked);

        // Act
        await ControlObject.SetAsync(isChecked);

        // Assert
        Assert.AreEqual(initialIsChecked, await ControlObject.IsCheckedAsync());
    }

    private void SetCheckboxState(bool isChecked)
    {
        ExecuteScript($"arguments[0].checked = {isChecked.ToString().ToLower()};", Driver.FindElement(Locator));
    }
}