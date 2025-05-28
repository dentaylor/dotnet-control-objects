using OpenQA.Selenium;

namespace SeleniumControlObjects
{
    public class Button
    {
        private readonly IWebElement _element;

        public Button(IWebElement element)
        {
            _element = element;
        }

        public void Click()
        {
            _element.Click();
        }
    }
}