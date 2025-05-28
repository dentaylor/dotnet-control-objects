using OpenQA.Selenium;
using SeleniumControlObjects;
using SeleniumControlObjectsTests;

[TestClass]
public class TextareaTests : TestBase<Textarea>
{
    [TestInitialize]
    public void Init()
    {
        Setup("textarea-test", By.Id("comments"));
    }

    [TestMethod]
    public void Set_ChangesTextareaValue()
    {
        // Arrange
        var textarea = ControlObject;

        // Act
        textarea.Set("This is a test comment.");

        // Assert
        Assert.AreEqual("This is a test comment.", textarea.Text);
    }

    [TestMethod]
    public void Value_ReturnsCurrentText()
    {
        // Arrange
        var textarea = ControlObject;
        textarea.Set("Multiline\nText");

        // Act
        var value = textarea.Text;

        // Assert
        Assert.AreEqual("Multiline\nText", value);
    }
}
