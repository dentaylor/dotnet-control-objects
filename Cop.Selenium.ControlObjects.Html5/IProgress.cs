namespace Cop.Selenium.ControlObjects.Html5;

public interface IProgress
{
    /// <summary>
    /// Gets the current value of the progress element.  
    /// </summary>
    double Value { get; }

    /// <summary>
    /// Gets the maximum value of the progress element. 
    /// </summary>
    double Max { get; }
}