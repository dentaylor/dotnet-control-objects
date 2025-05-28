namespace SeleniumControlObjects
{
    public interface IComboBox
    {
        void Set(string text);

        string Selected { get; }
    }
}