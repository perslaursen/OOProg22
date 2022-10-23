
/// <summary>
/// Base class for a full in-memory, read-only repository class.
/// The class implements IMockableRepository to allow external initialization of the Repository.
/// The class also implements ISearchableRepository, since Search is a read-only operation as well.
/// </summary>
/// <typeparam name="T">
/// Type of objects stored in the repository. 
/// This might be model data objects or DTO objects.
/// </typeparam>
public abstract class FullReadOnlyRepositoryBase<T> : 
    ReadOnlyRepositoryBase<T>, 
    IMockableRepository<T>,
    ISearchableRepository<T>
    where T : IHasId
{
    public void InitFromList(List<T> elements, bool useIds = true)
    {
        _repo.Clear();

        elements.ForEach(e => CreateInternal(e, useIds ? e.Id : null));
    }

    public List<T> Search(string searchTerm)
    {
        return _repo.Values.Where(e => SearchMatch(e, searchTerm)).ToList();
    }
   
    protected T CreateInternal(T t, int? hardId = null)
    {
        // Use hardId if provided, otherwise generate new key.
        int id = hardId ?? NextKey();

        t.Id = id;
        _repo[t.Id] = t;

        return t;
    }

    protected int NextKey()
    {
        return _repo.Keys.Count != 0 ? _repo.Keys.Max() + 1 : 1;
    }

    protected abstract bool SearchMatch(T t, string searchTerm);
}
