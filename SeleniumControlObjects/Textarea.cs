using OpenQA.Selenium;

namespace SeleniumControlObjects
{
    public class Textarea : ITextarea
    {
        private readonly IWebElement _element;

        public Textarea(IWebElement element)
        {
            _element = element;
        }

        public void Set(string text)
        {
            _element.Clear();
            _element.SendKeys(text);
        }

        public string Text => _element.GetAttribute("value");
    }
}