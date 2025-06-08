namespace SeleniumControlObjects;

public interface IMultiDropdown
{
    /// <summary>
    /// Selects the specified options by their visible text. 
    /// </summary>
    void Select(params string[] texts);

    /// <summary>
    /// Gets the currently selected options' visible text. 
    /// </summary>
    string[] Selected { get; }

    /// <summary>
    /// Gets all available options' visible text. 
    /// </summary>
    string[] Options { get; }

    /// <summary>
    /// Clears all selected options. 
    /// </summary>
    void Clear();
}