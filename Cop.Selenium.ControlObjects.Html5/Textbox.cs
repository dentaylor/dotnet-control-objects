using System;

namespace Cop.Selenium.ControlObjects.Html5;

public class Textbox(IWebElement element) : ITextbox
{
    public virtual TimeSpan SetTimeout => TimeSpan.FromSeconds(5);

    /// <summary>
    /// Gets the text value.
    /// </summary>
    public string Text => element.GetAttribute("value") ?? string.Empty;

    /// <summary>
    /// Sets the text value.
    /// </summary>
    /// <param name="text">Text to set.</param>
    public void Set(string text)
    {
        element.Clear();
        element.SendKeys(text);

        var isSet = () => Text == text;
        isSet.WaitUntilTrue(SetTimeout, $"Could not set text to '{text}' within the timeout. Actual value was '{Text}'");
    }
}
