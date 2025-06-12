using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class Checkbox(ILocateElements locator) : ICheckbox
{
    public async Task<bool> IsCheckedAsync()
    {
        return await locator.IsSelectedAsync();
    }

    public async Task SetAsync(bool? isChecked)
    {
        if (isChecked == null)
        {
            return;
        }

        if (await locator.IsSelectedAsync() != isChecked)
        {
            await locator.ClickAsync();
        }
    }
}
