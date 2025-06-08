namespace SeleniumControlObjects
{
    public interface IDropdown
    {
        /// <summary>
        /// List of all options in the dropdown.
        /// </summary>
        string[] Options { get; }

        /// <summary>
        /// Currently selected option.
        /// </summary>
        string Selected { get; }
        
        /// <summary>
        /// Selects an option by its text.
        /// </summary>
        void Select(string text);
    }
}