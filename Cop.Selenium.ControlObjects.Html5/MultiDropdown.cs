using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Cop.Selenium.ControlObjects.Html5;

public class MultiDropdown(IWebElement element) : IMultiDropdown
{
    private SelectElement SelectElement => new(element);

    public string[] Selected => [.. SelectElement.AllSelectedOptions.Select(option => option.Text)];

    public string[] Options => [.. SelectElement.Options.Select(x => x.Text)];

    public void Select(params string[] texts)
    {
        if (texts == null || texts.Length == 0)
        {
            return;
        }

        var missingOptions = texts.Except(Options).ToArray();
        if (missingOptions.Length > 0)
        {
            throw new ArgumentException($"Options not found: {string.Join(", ", missingOptions)}");
        }

        foreach (var text in texts)
        {
            SelectElement.SelectByText(text);
        }
    }

    public void Clear()
    {
        SelectElement.DeselectAll();
    }
}