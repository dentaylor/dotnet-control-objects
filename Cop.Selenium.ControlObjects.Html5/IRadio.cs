namespace Cop.Selenium.ControlObjects.Html5;

public interface IRadio
{
    /// <summary>
    /// Clicks the radio button. 
    /// </summary>
    void Click();

    /// <summary>
    /// Gets a value indicating whether the radio button is selected. 
    /// </summary>
    bool IsSet { get; }
}