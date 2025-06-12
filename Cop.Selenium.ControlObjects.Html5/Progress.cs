using System;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class Progress(ILocateElements locator) : IProgress
{
    public Task<double> GetValueAsync() => ParseAttributeAsync("value");

    public Task<double> GetMaxAsync() => ParseAttributeAsync("max");

    private async Task<double> ParseAttributeAsync(string attributeName)
    {
        var attr = await locator.GetDomAttributeAsync(attributeName)
            ?? throw new InvalidOperationException($"{attributeName} attribute was null");

        return double.Parse(attr);
    }
}