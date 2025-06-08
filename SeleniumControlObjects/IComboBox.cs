namespace SeleniumControlObjects;

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