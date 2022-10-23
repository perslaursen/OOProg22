
/// <summary>
/// Base class for an in-memory, read-only repository class.
/// Data is stored in a Dictionary.
/// Note that methods are described in the corresponding interface definition.
/// </summary>
/// <typeparam name="T">
/// Type of objects stored in the repository. 
/// This might be model data objects or DTO objects.
/// </typeparam>
public abstract class ReadOnlyRepositoryBase<T> : IReadOnlyRepository<T> where T : IHasId
{
    protected Dictionary<int, T> _repo;

    public ReadOnlyRepositoryBase()
    {
        _repo = new Dictionary<int, T>();
    }

    public T? Read(int id)
    {
        return _repo.ContainsKey(id) ? _repo[id] : default;
    }

    public List<T> GetAll()
    {
        return _repo.Values.ToList();
    }

    public Dictionary<int, T> GetAllAsDictionary()
    {
        // The internal Dictionary is copied, to avoid retuning a direct reference.
        return _repo.ToDictionary(e => e.Key, e => e.Value);
    }

    public override string ToString()
    {
        List<T> elements = GetAll();

        string result = $"{typeof(T)} repository, {elements.Count} elements\n";

        foreach (T t in elements)
        {
            result += t.ToString();
            result += "\n";
        }

        return result;
    }
}
