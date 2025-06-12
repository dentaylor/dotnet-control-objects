using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

/// <summary>
/// Interface for locating and interacting with HTML elements in a web page.
/// </summary>
public interface ILocateElements
{
    /// <summary>
    /// Finds a single element using the specified CSS selector. 
    /// </summary>
    /// <param name="cssSelector"></param>
    Task<ILocateElements> FindAsync(string cssSelector);

    /// <summary>
    /// Finds all elements matching the specified CSS selector. 
    /// </summary>
    /// <param name="cssSelector"></param>
    Task<IEnumerable<ILocateElements>> FindAllAsync(string cssSelector);

    /// <summary>
    /// Clicks the element. 
    /// </summary>
    Task ClickAsync();
    
    /// <summary>
    /// Asynchronously retrieves a text string.
    /// </summary>
    Task<string> GetTextAsync();

    /// <summary>
    /// Asynchronously retrieves the value of an attribute from the element. 
    /// </summary>
    Task<string> GetAttributeAsync(string attribute);

    /// <summary>
    /// Asynchronously retrieves the value of a DOM attribute from the element.
    /// </summary>
    Task<string> GetDomAttributeAsync(string attribute);

    /// <summary>
    /// Checks if the element is selected (e.g., for checkboxes or radio buttons). 
    /// </summary>
    Task<bool> IsSelectedAsync();

    /// <summary>
    /// Clears the content of the element, such as an input field or textarea. 
    /// </summary>
    Task ClearAsync();

    /// <summary>
    /// Sends a sequence of keystrokes to the element, such as typing text into an input field. 
    /// </summary>
    Task SendKeysAsync(string text);
}

