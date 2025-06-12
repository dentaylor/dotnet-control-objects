using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5
{
    public interface IDropdown
    {
        /// <summary>
        /// List of all options in the dropdown.
        /// </summary>
        Task<string[]> GetOptionsAsync();

        /// <summary>
        /// Currently selected option.
        /// </summary>
        Task<string> GetSelectedAsync();

        /// <summary>
        /// Selects an option by its text.
        /// </summary>
        Task SelectAsync(string text);
    }
}