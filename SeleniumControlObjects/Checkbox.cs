namespace SeleniumControlObjects;

public class Checkbox(IWebElement element) : ICheckbox
{
    public bool IsChecked => element.Selected;

    public void Set(bool? isChecked)
    {
        if(isChecked == null)
        {
            return;
        }

        if (!element.Selected != IsChecked)
        {
            element.Click();
        }
    }
}