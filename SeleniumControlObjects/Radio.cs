using OpenQA.Selenium;

namespace SeleniumControlObjects
{
    public class Radio : IRadio
    {
        private readonly IWebElement _element;

        public Radio(IWebElement element)
        {
            _element = element;
        }

        public void Set(bool? isSet)
        {
            if (isSet == true && !_element.Selected)
            {
                _element.Click();
            }
        }

        public string IsSet => _element.Selected.ToString().ToLower();
    }
}