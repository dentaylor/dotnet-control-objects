using OpenQA.Selenium;

namespace SeleniumControlObjects
{
    public class Meter : IMeter
    {
        private readonly IWebElement _element;

        public Meter(IWebElement element)
        {
            _element = element;
        }

        public double Value => double.Parse(_element.GetAttribute("value"));
        public double Min => double.Parse(_element.GetAttribute("min") ?? "0");
        public double Max => double.Parse(_element.GetAttribute("max") ?? "1");
    }
}