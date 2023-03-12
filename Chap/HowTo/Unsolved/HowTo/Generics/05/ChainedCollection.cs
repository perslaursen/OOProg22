
public class ChainedCollection<T> : IChainedCollection<T> where T : IHasId
{
    public ChainLink<T>? Start { get; private set; }
    public ChainLink<T>? End { get; private set; }

    public bool IsEmpty
    {
        get { return true; } // TODO
    }

    public int Count
    {
        get { return 0; } // TODO
    }

    public ChainedCollection()
    {
        Start = null;
        End = null;
    }

    public void AddStart(T value)
    {
        // TODO
    }

    public void AddEnd(T value)
    {
        // TODO
    }

    public T? Read(int id)
    {
        return default; // TODO
    }

    public List<T> GetAll()
    {
        List<T> list = new List<T>();

        // TODO

        return list;
    }

    #region Private helper methods

    private void AddFirstLink(T value)
    {
        Start = new ChainLink<T>(value);
        End = Start;
    }

    private int CountRest(ChainLink<T>? link)
    {
        if (link == null)
            return 0;

        return 1 + CountRest(link.Next);
    }

    private T? ReadRest(ChainLink<T>? link, int id)
    {
        if (link == null)
            return default;

        if (link.Value.Id == id)
            return link.Value;

        return ReadRest(link.Next, id);
    }

    #endregion
}
