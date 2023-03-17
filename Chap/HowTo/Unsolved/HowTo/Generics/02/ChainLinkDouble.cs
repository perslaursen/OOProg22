
public class ChainLinkDouble
{
    public double Value { get; set; }
    public ChainLinkDouble? Next { get; set; }

    public ChainLinkDouble(double value, ChainLinkDouble? next)
    {
        Value = value;
        Next = next;
    }

    public ChainLinkDouble(double value)
    {
        Value = value;
        Next = null;
    }
}
