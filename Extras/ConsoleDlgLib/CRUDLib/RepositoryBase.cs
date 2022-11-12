
/// <summary>
/// Base in-memory implementation of the IRepository<T> interface.
/// Objects are stored in a Dictionary.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository</typeparam>
public abstract class RepositoryBase<T> : IRepository<T> where T : class, IId, new()
{
    protected Dictionary<int, T> _data = new Dictionary<int, T>();

    public T Create()
    {
        T t = new T() { Id = NextId() };
        _data.Add(t.Id, t); 

        return t;
    }

    public T? Read(int id)
    {
        return _data.ContainsKey(id) ? _data[id] : null;
    }

    public bool Delete(int id)
    {
        return _data.Remove(id);
    }

    public void Update(T t)
    {
        _data[t.Id] = t;
    }

    public List<T> GetAll()
    {
        return new List<T>(_data.Values);
    }

    public List<T> Search(string searchTerm)
    {
        return _data.Values.Where(t => SearchMatch(t, searchTerm)).ToList();
    }

    protected abstract bool SearchMatch(T t, string searchTerm);

    private int NextId()
    {
        if (_data.Count == 0)
            return 1;
        else
            return _data.Keys.Max() + 1;
    }

}
