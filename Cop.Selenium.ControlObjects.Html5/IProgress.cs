using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public interface IProgress
{
    /// <summary>
    /// Gets the current value of the progress element.  
    /// </summary>
    Task<double> GetValueAsync();

    /// <summary>
    /// Gets the maximum value of the progress element. 
    /// </summary>
    Task<double> GetMaxAsync();
}