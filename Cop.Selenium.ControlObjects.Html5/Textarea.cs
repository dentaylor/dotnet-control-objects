using System;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class Textarea(ILocateElements locator) : ITextarea
{
    public virtual TimeSpan SetTimeout => TimeSpan.FromSeconds(5);

    public async Task<string> GetTextAsync() => await locator.GetAttributeAsync("value") ?? string.Empty;

    public async Task SetAsync(string text)
    {
        await locator.ClearAsync();
        await locator.SendKeysAsync(text);

        Func<bool> isSet = () => Task.Run(async () => await GetTextAsync() == text).Result;
        isSet.WaitUntilTrue(SetTimeout, $"Could not set text to '{text}' within the timeout. Actual value was '{await GetTextAsync()}'");
    }
}