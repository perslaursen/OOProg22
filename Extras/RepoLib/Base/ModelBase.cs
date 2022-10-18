
public abstract class ModelBase<T> : IHasId
{
    public int Id { get; set; }

    public ModelBase(int id = 0)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"{typeof(T)} with Id {Id}";
    }
}
