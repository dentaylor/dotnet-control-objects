using OpenQA.Selenium;

namespace SeleniumControlObjects
{
    public class ComboBox : IComboBox
    {
        private readonly IWebElement _element;

        public ComboBox(IWebElement element)
        {
            _element = element;
        }

        public void Set(string text)
        {
            _element.Clear();
            _element.SendKeys(text);
        }

        public string Selected => _element.GetAttribute("value");
    }
}