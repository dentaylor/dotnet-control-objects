namespace Cop.Selenium.ControlObjects.Html5;

public class Radio(IWebElement element) : IRadio
{
    public bool IsSet => element.Selected;

    public void Click()
    {
        element.Click();
    }
}