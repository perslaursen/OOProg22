
public class ChainedCollectionDone<T> : IChainedCollection<T> where T : IHasId
{
    public ChainLink<T>? Start { get; private set; }
    public ChainLink<T>? End { get; private set; }

    public bool IsEmpty
    {
        get { return Start is null; }
    }

    public int Count
    {
        get { return CountRest(Start); }
    }

    public ChainedCollectionDone()
    {
        Start = null;
        End = null;
    }

    public void AddStart(T value)
    {
        if (IsEmpty)
        {
            AddFirstLink(value);
        }
        else
        {
            ChainLink<T> newLink = new ChainLink<T>(value, Start);
            Start = newLink;
        }
    }

    public void AddEnd(T value)
    {
        if (IsEmpty)
        {
            AddFirstLink(value);
        }
        else
        {
            ChainLink<T> newLink = new ChainLink<T>(value);
            End.Next = newLink;
            End = newLink;
        }
    }

    public T? Read(int id)
    {
        return ReadRest(Start, id);
    }

    public List<T> GetAll()
    {
        List<T> list = new List<T>();

        ChainLink<T>? link = Start;
        while (link != null)
        {
            list.Add(link.Value);
            link = link.Next;
        }

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
