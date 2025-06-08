namespace SeleniumControlObjects;

public interface IMeter
{
    /// <summary>
    /// Gets the value of the meter.
    /// </summary>
    double Value { get; }

    /// <summary>
    /// Gets the minimum value of the meter.
    /// </summary>
    double Min { get; }

    /// <summary>
    /// Gets the maximum value of the meter.
    /// </summary>
    double Max { get; }

    /// <summary>
    /// Gets the low value of the meter.
    /// </summary>
    double Low { get; }

    /// <summary>
    /// Gets the high value of the meter. 
    /// </summary>
    double High { get; }

    /// <summary>
    /// Gets the optimum value of the meter. 
    /// </summary>
    double Optimum { get; }
}