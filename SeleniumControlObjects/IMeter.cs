namespace SeleniumControlObjects
{
    public interface IMeter
    {
        double Value { get; }

        double Min { get; }

        double Max { get; }
    }
}