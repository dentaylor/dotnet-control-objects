namespace Cop.Selenium.ControlObjects.Html5;

public class Button(IWebElement element) : IButton
{
    public void Click()
    {
        element.Click();
    }
}