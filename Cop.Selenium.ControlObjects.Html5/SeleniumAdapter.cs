using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cop.Selenium.ControlObjects.Html5;

public class SeleniumAdapter(IWebDriver driver, IWebElement element) : ILocateElements
{
    public Task<ILocateElements> FindAsync(string cssSelector) =>
        Task.FromResult<ILocateElements>(
            new SeleniumAdapter(driver, element.FindElement(By.CssSelector(cssSelector))));

    public Task<IEnumerable<ILocateElements>> FindAllAsync(string cssSelector) =>
        Task.FromResult<IEnumerable<ILocateElements>>(
            element.FindElements(By.CssSelector(cssSelector))
                   .Select(el => new SeleniumAdapter(driver, el)));

    public Task ClickAsync()
    {
        element.Click();
        return Task.CompletedTask;
    }

    public Task<string> GetTextAsync() =>
        Task.FromResult(element.Text);

    public Task<string> GetAttributeAsync(string attribute) =>
        Task.FromResult(element.GetAttribute(attribute));

    public Task<string> GetDomAttributeAsync(string attribute) =>
        Task.FromResult(element.GetDomAttribute(attribute));

    public Task<bool> IsSelectedAsync() =>
        Task.FromResult(element.Selected);
}
