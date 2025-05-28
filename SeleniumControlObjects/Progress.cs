using OpenQA.Selenium;

namespace SeleniumControlObjects
{
    public class Progress : IProgress
    {
        private readonly IWebElement _element;

        public Progress(IWebElement element)
        {
            _element = element;
        }

        public double Value => double.Parse(_element.GetAttribute("value") ?? "0");
        public double Max => double.Parse(_element.GetAttribute("max") ?? "1");
    }
}