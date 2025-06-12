using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public interface IMultiDropdown
{
    /// <summary>
    /// Selects the specified options by their visible text. 
    /// </summary>
    Task SelectAsync(params string[] texts);

    /// <summary>
    /// Gets the currently selected options' visible text. 
    /// </summary>
    Task<string[]> GetSelectedAsync();

    /// <summary>
    /// Gets all available options' visible text. 
    /// </summary>
    Task<string[]> GetOptionsAsync();

    /// <summary>
    /// Clears all selected options. 
    /// </summary>
    Task ClearAsync();
}