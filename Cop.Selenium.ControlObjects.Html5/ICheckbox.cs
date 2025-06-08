namespace Cop.Selenium.ControlObjects.Html5
{
    public interface ICheckbox
    {
        /// <summary>
        /// Sets the checkbox state. If null is passed, the state is not changed.
        /// </summary>
        void Set(bool? isChecked);

        /// <summary>
        /// Gets whether the checkbox is checked.
        /// </summary>
        bool IsChecked { get; }
    }
}