namespace SeleniumControlObjects;

public class Button(IWebElement element) : IButton
{
    public void Click()
    {
        element.Click();
    }
}