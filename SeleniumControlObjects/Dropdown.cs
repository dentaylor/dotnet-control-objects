using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumControlObjects;

public class Dropdown(IWebElement element) : IDropdown
{
    private SelectElement SelectElement => new(element);

    public string[] Options => [.. SelectElement.Options.Select(o => o.Text)];

    public string Selected => SelectElement.SelectedOption?.Text ?? string.Empty;

    public void Select(string text)
    {
        if(string.IsNullOrEmpty(text))
        {
            return;
        }

        if (Selected == text)
        {
            return;
        }

        var match = SelectElement.Options.FirstOrDefault(o => o.Text == text)
            ?? throw new ArgumentException($"Option '{text}' not found in dropdown.");

        SelectElement.SelectByText(text);
    }
}
