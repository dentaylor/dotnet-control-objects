using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class Radio(ILocateElements locator) : IRadio
{
    public async Task<bool> IsSetAsync() => await locator.IsSelectedAsync();

    public async Task ClickAsync()
    {
        await locator.ClickAsync();
    }
}