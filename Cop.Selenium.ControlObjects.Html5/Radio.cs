namespace SeleniumControlObjects;

public class Radio(IWebElement element) : IRadio
{
    public bool IsSet => element.Selected;

    public void Click()
    {
        element.Click();
    }
}