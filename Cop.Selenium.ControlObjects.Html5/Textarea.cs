using System;

namespace Cop.Selenium.ControlObjects.Html5;

public class Textarea(IWebElement element) : ITextarea
{
    public virtual TimeSpan SetTimeout => TimeSpan.FromSeconds(5);

    public string Text => element.GetAttribute("value") ?? string.Empty;

    public void Set(string text)
    {
        element.Clear();
        element.SendKeys(text);

        var isSet = () => Text == text;
        isSet.WaitUntilTrue(SetTimeout, $"Could not set text to '{text}' within the timeout. Actual value was '{Text}'");
    }
}