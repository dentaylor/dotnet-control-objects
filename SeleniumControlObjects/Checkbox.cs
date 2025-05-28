using OpenQA.Selenium;

namespace SeleniumControlObjects
{
    public class Checkbox
    {
        private readonly IWebElement _element;

        public Checkbox(IWebElement element)
        {
            _element = element;
        }

        public bool IsChecked => _element.Selected;

        public void Set(bool? isChecked)
        {
            if (!_element.Selected)
                _element.Click();
        }
    }
}