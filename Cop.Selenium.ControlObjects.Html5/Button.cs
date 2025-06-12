using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class Button(ILocateElements locator) : IButton
{
    public async Task ClickAsync()
    {
        await locator.ClickAsync();
    }
}
