using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5
{
    public interface ITextbox
    {
        /// <summary>
        /// Sets the text value. 
        /// </summary>
        Task SetAsync(string text);

        /// <summary>
        /// Gets the text value.   
        /// </summary>
        Task<string> GetTextAsync();
    }
}