
public class ChainLinkString
{
    public string Value { get; set; }
    public ChainLinkString? Next { get; set; }

    public ChainLinkString(string value, ChainLinkString? next)
    {
        Value = value;
        Next = next;
    }

    public ChainLinkString(string value)
    {
        Value = value;
        Next = null;
    }
}
