using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class MultiDropdown(ILocateElements locator) : IMultiDropdown
{
    public async Task ClearAsync()
    {
        var options = await GetOptionElementsAsync();
        foreach (var option in options)
        {
            if (await option.IsSelectedAsync())
            {
                await option.ClickAsync();
            }
        }
    }

    public async Task<string[]> GetOptionsAsync()
    {
        var options = await GetOptionElementsAsync();
        var texts = new List<string>();

        foreach (var option in options)
        {
            var text = await option.GetTextAsync();
            texts.Add(text.Trim());
        }
        return [.. texts];
    }

    public async Task<string[]> GetSelectedAsync()
    {
        var selectedOptions = new List<string>();

        var options = await GetOptionElementsAsync();
        foreach (var option in options)
        {
            if (await option.IsSelectedAsync())
            {
                selectedOptions.Add((await option.GetTextAsync()).Trim());
            }
        }
        return [.. selectedOptions];
    }

    public async Task SelectAsync(params string[] texts)
    {
        foreach (var text in texts)
        {
            await SelectAsync(text);
        }
    }

    private async Task SelectAsync(string text)
    {
        var options = await GetOptionElementsAsync();
        foreach (var option in options)
        {
            var optionText = (await option.GetTextAsync()).Trim();
            if (optionText.Equals(text, StringComparison.OrdinalIgnoreCase))
            {
                if (!await option.IsSelectedAsync())
                {
                    await option.ClickAsync();
                }
                return;
            }
        }
        throw new InvalidOperationException($"Option with text '{text}' not found.");
    }

    private async Task<IEnumerable<ILocateElements>> GetOptionElementsAsync()
    {
        return await locator.FindAllAsync("option");
    }
}