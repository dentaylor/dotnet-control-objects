using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class ComboBox(ILocateElements locator) : IComboBox
{
    public async Task SetAsync(string text)
    {
        await locator.ClearAsync();
        await locator.SendKeysAsync(text);
    }

    public async Task<string> GetSelectedAsync()
    {
        return await locator.GetAttributeAsync("value") ?? string.Empty;
    }
}