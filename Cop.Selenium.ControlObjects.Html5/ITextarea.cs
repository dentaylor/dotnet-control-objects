namespace Cop.Selenium.ControlObjects.Html5;

public interface ITextarea
{
    /// <summary>
    /// Sets the text value. 
    /// </summary>
    void Set(string text);

    /// <summary>
    /// Gets the text value.   
    /// </summary>
    string Text { get; }
}