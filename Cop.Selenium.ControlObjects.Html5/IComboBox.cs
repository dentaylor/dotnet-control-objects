using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public interface IComboBox
{
    /// <summary>
    /// Sets the text value. 
    /// </summary>
    Task SetAsync(string text);

    /// <summary>
    /// Gets the selected value.  
    /// </summary>
    Task<string> GetSelectedAsync();
}