namespace SeleniumControlObjects
{
    public interface IRadio
    {
        void Set(bool? isSet);

        string IsSet { get; }
    }
}