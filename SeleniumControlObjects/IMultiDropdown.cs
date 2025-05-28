namespace SeleniumControlObjects
{
    public interface IMultiDropdown
    {
        void Select(params string[] texts);

        string[] Selected { get; }
    }
}