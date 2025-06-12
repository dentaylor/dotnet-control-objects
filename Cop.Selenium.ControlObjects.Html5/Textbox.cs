using System;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class Textbox(ILocateElements locator) : ITextbox
{
    public virtual TimeSpan SetTimeout => TimeSpan.FromSeconds(5);

    /// <summary>
    /// Gets the text value.
    /// </summary>
    public async Task<string> GetTextAsync() => await locator.GetAttributeAsync("value") ?? string.Empty;

    /// <summary>
    /// Sets the text value.
    /// </summary>
    /// <param name="text">Text to set.</param>
    public async Task SetAsync(string text)
    {
        await locator.ClearAsync();
        await locator.SendKeysAsync(text);

        Func<bool> isSet = () => GetTextAsync().Result == text;
        isSet.WaitUntilTrue(SetTimeout, $"Could not set text to '{text}' within the timeout. Actual value was '{await GetTextAsync()}'");
    }
}
