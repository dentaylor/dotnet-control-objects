using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5
{
    public interface IButton
    {
        /// <summary>
        /// Asynchronously clicks the button.   
        /// </summary>
        Task ClickAsync();
    }
}