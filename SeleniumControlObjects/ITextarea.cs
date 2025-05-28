namespace SeleniumControlObjects
{
    public interface ITextarea
    {
        void Set(string text);

        string Text { get; }
    }
}