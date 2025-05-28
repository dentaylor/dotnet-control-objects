using OpenQA.Selenium;

namespace SeleniumControlObjects
{
    public class Textbox
    {
        private IWebElement _element;

        public Textbox(IWebElement element)
        {
            _element = element;
        }

        /// <summary>
        /// Gets the text value.
        /// </summary>
        public string Text => _element.GetAttribute("value");

        /// <summary>
        /// Sets the text value.
        /// </summary>
        /// <param name="text">Text to set.</param>
        public void Set(string text)
        {
            _element.Clear();
            _element.SendKeys(text);

            var isSet = () => Text == text;
            isSet.WaitUntilTrue(TimeSpan.FromSeconds(5), $"Could not set text to '{text}' within the timeout. Actual value was '{Text}'");
        }
    }
}
