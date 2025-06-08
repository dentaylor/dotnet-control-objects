namespace Cop.Selenium.ControlObjects.Html5;

public interface IComboBox
{
    /// <summary>
    /// Sets the text value. 
    /// </summary>
    void Set(string text);

    /// <summary>
    /// Gets the selected value.  
    /// </summary>
    string Selected { get; }
}