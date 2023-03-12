
public class IdBase<T> : IHasId
{
    public int Id { get; }

    public IdBase(int id)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"[{typeof(T).Name}] {Id} -> ";
    }
}
