using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumControlObjects
{
    public class MultiDropdown : IMultiDropdown
    {
        private readonly IWebElement _element;

        public MultiDropdown(IWebElement element)
        {
            _element = element;
        }

        public void Select(params string[] texts)
        {
            var select = new SelectElement(_element);

            foreach (var text in texts)
            {
                select.SelectByText(text);
            }
        }

        public string[] Selected
        {
            get
            {
                var select = new SelectElement(_element);
                return select.AllSelectedOptions
                             .Select(option => option.Text)
                             .ToArray();
            }
        }
    }
}