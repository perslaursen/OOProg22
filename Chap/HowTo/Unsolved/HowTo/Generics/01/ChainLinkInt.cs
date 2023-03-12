
public class ChainLinkInt
{
    public int Value { get; set; }
    public ChainLinkInt? Next { get; set; }

    public ChainLinkInt(int value, ChainLinkInt? next)
    {
        Value = value;
        Next = next;
    }

    public ChainLinkInt(int value)
    {
        Value = value;
        Next = null;
    }
}
