namespace Cop.Selenium.ControlObjects.Html5;

public class ComboBox(IWebElement element) : IComboBox
{
    public string Selected => element.GetAttribute("value") ?? string.Empty;

    public void Set(string text)
    {
        element.Clear();
        element.SendKeys(text);
    }
}