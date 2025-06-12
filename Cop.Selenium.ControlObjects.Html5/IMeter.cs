using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public interface IMeter
{
    /// <summary>
    /// Gets the value of the meter.
    /// </summary>
    Task<double> GetValueAsync();

    /// <summary>
    /// Gets the minimum value of the meter.
    /// </summary>
    Task<double> GetMinAsync();

    /// <summary>
    /// Gets the maximum value of the meter.
    /// </summary>
    Task<double> GetMaxAsync();

    /// <summary>
    /// Gets the low value of the meter.
    /// </summary>
    Task<double> GetLowAsync();

    /// <summary>
    /// Gets the high value of the meter. 
    /// </summary>
    Task<double> GetHighAsync();

    /// <summary>
    /// Gets the optimum value of the meter. 
    /// </summary>
    Task<double> GetOptimumAsync();
}