using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumControlObjects
{
    public class Dropdown
    {
        private readonly SelectElement _selectElement;

        public Dropdown(IWebElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            _selectElement = new SelectElement(element);
        }

        public List<string> Options
        {
            get => _selectElement.Options.Select(o => o.Text).ToList();
        }

        public string Selected
        {
            get => _selectElement.SelectedOption?.Text ?? string.Empty;
        }

        public void Select(string text)
        {
            var match = _selectElement.Options.FirstOrDefault(o => o.Text == text);
            if (match == null)
                throw new InvalidOperationException($"Option '{text}' not found in dropdown.");

            _selectElement.SelectByText(text);
        }
    }
}
