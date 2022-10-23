
/// <summary>
/// Base class for a full in-memory repository class.
/// The abstract "...Action" methods are intended to give subclasses 
/// an option to perform an action after the content of the Repository 
/// has been changed. This could e.g. be to save the Repository to 
/// persistent storage.
/// </summary>
/// <typeparam name="T">
/// Type of objects stored in the repository. 
/// This might be model data objects or DTO objects.
/// </typeparam>
public abstract class RepositoryBase<T> : 
    FullReadOnlyRepositoryBase<T>, 
    IRepository<T> where T : IHasId
{
    public int Create(T t, int? hardId = null)
    {
        T tCreated = CreateInternal(t, hardId);

        CreateAction(tCreated);

        return tCreated.Id;
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

    public void Clear()
    {
        _repo.Clear();

        ClearAction();
    }

    protected abstract void CreateAction(T t);
    protected abstract void UpdateAction(T tEx, T tNew);
    protected abstract void DeleteAction(int id);
    protected abstract void ClearAction();
}
