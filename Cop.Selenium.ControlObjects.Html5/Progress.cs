using System;

namespace SeleniumControlObjects;

public class Progress(IWebElement element) : IProgress
{
    public double Value => ParseAttribute("value");

    public double Max => ParseAttribute("max");

    private double ParseAttribute(string attributeName)
    {
        var attr = element.GetDomAttribute(attributeName)
            ?? throw new InvalidOperationException($"{attributeName} attribute was null");

        return double.Parse(attr);
    }
}