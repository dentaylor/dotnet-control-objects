using System;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class Meter(ILocateElements locator) : IMeter
{
    public Task<double> GetValueAsync() => ParseAttribute("value");

    public Task<double> GetMinAsync() => ParseAttribute("min");

    public Task<double> GetMaxAsync() => ParseAttribute("max");

    public Task<double> GetLowAsync() => ParseAttribute("low");

    public Task<double> GetHighAsync() => ParseAttribute("high");

    public Task<double> GetOptimumAsync() => ParseAttribute("optimum");

    private async Task<double> ParseAttribute(string attributeName)
    {
        var attr = await locator.GetDomAttributeAsync(attributeName)
            ?? throw new InvalidOperationException($"{attributeName} attribute was null");

        return double.Parse(attr);
    }
}
