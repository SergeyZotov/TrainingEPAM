namespace Task3
{
    public interface IIndexable : ISeries
    {
        double this[int index] { get; }
    }
}
