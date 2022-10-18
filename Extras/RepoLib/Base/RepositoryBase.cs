
public abstract class RepositoryBase<T> : IRepository<T> where T : IHasId
{
    private Dictionary<int, T> _repo;

    public RepositoryBase()
    {
        _repo = new Dictionary<int, T>();
    }

    public int Create(T t, int? hardId = null)
    {
        T tCreated = CreateInternal(t, hardId);

        CreateAction(tCreated);

        return tCreated.Id;
    }

    public T? Read(int id)
    {
        return _repo.ContainsKey(id) ? _repo[id] : default;
    }

    public bool Update(int id, T t)
    {
        if (!_repo.ContainsKey(id))
            return false;

        UpdateAction(_repo[id], t);

        return true;
    }

    public bool Delete(int id)
    {
        if (!_repo.Remove(id))
            return false;

        DeleteAction(id);

        return true;
    }

    public List<T> GetAll()
    {
        return _repo.Values.ToList();
    }

    public Dictionary<int, T> GetAllAsDictionary()
    {
        return _repo;
    }

    public void Clear()
    {
        _repo.Clear();

        ClearAction();
    }

    public List<T> Search(string searchTerm)
    {
        List<T> matches = new List<T>();

        foreach (T t in _repo.Values)
        {
            if (SearchMatch(t, searchTerm))
                matches.Add(t);
        }

        return matches;
    }

    public void InitFromList(List<T> elements, bool useIds = true)
    {
        _repo.Clear();

        foreach (T t in elements)
        {
            CreateInternal(t, useIds ? t.Id : null);
        }
    }

    public override string ToString()
    {
        string result = $"{typeof(T)} repository, {_repo.Count} elements\n";

        foreach (T t in _repo.Values)
        {
            result += t.ToString();
            result += "\n";
        }

        return result;
    }

    protected abstract bool SearchMatch(T t, string searchTerm);
    protected abstract void CreateAction(T t);
    protected abstract void UpdateAction(T tEx, T tNew);
    protected abstract void DeleteAction(int id);
    protected abstract void ClearAction();

    private int NextKey()
    {
        return _repo.Keys.Count != 0 ? _repo.Keys.Max() + 1 : 1;
    }

    private T CreateInternal(T t, int? hardId = null)
    {
        int id = hardId ?? NextKey();

        t.Id = id;
        _repo[t.Id] = t;

        return t;
    }
}
