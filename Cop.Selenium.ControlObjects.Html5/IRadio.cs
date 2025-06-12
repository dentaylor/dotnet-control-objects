using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public interface IRadio
{
    /// <summary>
    /// Clicks the radio button. 
    /// </summary>
    Task ClickAsync();

    /// <summary>
    /// Gets a value indicating whether the radio button is selected. 
    /// </summary>
    Task<bool> IsSetAsync();
}