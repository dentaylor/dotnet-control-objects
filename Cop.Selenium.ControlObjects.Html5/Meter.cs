using System;

namespace SeleniumControlObjects;

public class Meter(IWebElement element) : IMeter
{
    public double Value => ParseAttribute("value");

    public double Min => ParseAttribute("min");

    public double Max => ParseAttribute("max");

    public double Low => ParseAttribute("low");

    public double High => ParseAttribute("high");

    public double Optimum => ParseAttribute("optimum");

    private double ParseAttribute(string attributeName)
    {
        var attr = element.GetDomAttribute(attributeName)
            ?? throw new InvalidOperationException($"{attributeName} attribute was null");

        return double.Parse(attr);
    }
}
