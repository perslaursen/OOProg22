
public class ChainLink<T>
{
    public T Value { get; set; }
    public ChainLink<T>? Next { get; set; }

    public ChainLink(T value, ChainLink<T>? next)
    {
        Value = value;
        Next = next;
    }

    public ChainLink(T value)
    {
        Value = value;
        Next = null;
    }
}
