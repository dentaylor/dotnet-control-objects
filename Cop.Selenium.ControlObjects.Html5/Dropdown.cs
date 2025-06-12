using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class Dropdown(ILocateElements locator) : IDropdown
{
    public async Task<string[]> GetOptionsAsync()
    {
        var optionElements = await GetOptionElementsAsync();
        return await Task.WhenAll(optionElements.Select(x => x.GetTextAsync()));
    }

    public async Task<string> GetSelectedAsync()
    {
        var options = await GetOptionElementsAsync();
        foreach (var option in options)
        {
            if (await option.IsSelectedAsync())
            {
                return (await option.GetTextAsync()).Trim();
            }
        }
        return null;
    }

    public async Task SelectAsync(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return;
        }

        var options = await GetOptionElementsAsync();

        foreach (var option in options)
        {
            var optionText = (await option.GetTextAsync()).Trim();
            if (optionText.Equals(text, StringComparison.OrdinalIgnoreCase))
            {
                await option.ClickAsync();
                return;
            }
        }

        throw new InvalidOperationException($"Option with text '{text}' not found.");
    }

    public async Task<IEnumerable<ILocateElements>> GetOptionElementsAsync()
    {
        return await locator.FindAllAsync("option");
    }
}
