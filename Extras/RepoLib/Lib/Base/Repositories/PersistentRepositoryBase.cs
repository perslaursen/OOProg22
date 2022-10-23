
/// <summary>
/// Base class for a full in-memory repository class, with persistency functionality.
/// Any ...Action will unconditionally call Save().
/// </summary>
/// <typeparam name="T">
/// Type of objects stored in the repository. 
/// This might be model data objects or DTO objects.
/// </typeparam>
public abstract class PersistentRepositoryBase<T> : RepositoryBase<T>, IPersistentRepository<T> where T : IHasId
{
    /// <summary>
    /// Constructor, may load data from persistent storage.
    /// </summary>
    /// <param name="loadOnCreation">Controls whether or not data from persisten storage is loaded on creation</param>
    public PersistentRepositoryBase(bool loadOnCreation = true)
    {
        if (loadOnCreation)
            Load();
    }

    protected override void CreateAction(T t)
    {
        Save();
    }

    protected override void UpdateAction(T tEx, T tNew)
    {
        UpdateObject(tEx, tNew);
        Save();
    }

    protected override void DeleteAction(int id)
    {
        Save();
    }

    protected override void ClearAction()
    {
        Save();
    }

    /// <summary>
    /// Reads all data from persistent storage into the repository.
    /// Any existing data in the repository is purged.
    /// </summary>
    public virtual void Load()
    {
        InitFromList(ReadAllFromDataSource());
    }

    /// <summary>
    /// Saves all data in the repository to persistent storage.
    /// Any existing data in persistent storage is overwritten.
    /// </summary>
    public virtual void Save()
    {
        SaveAllToDataSource(GetAll());
    }

    /// <summary>
    /// This method should performs the actual updating of an object,
    /// and must therefore be implemented in a derived class.
    /// </summary>
    /// <param name="tEx">Existing object to update</param>
    /// <param name="tNew">New object, containing data to use for updating</param>
    protected abstract void UpdateObject(T tEx, T tNew);

    /// <summary>
    /// This method should read all data from persistent storage.
    /// The specific way to do this must be implemented in a derived class.
    /// </summary>
    /// <returns>List of objects of type T, read from persistent storage</returns>
    protected abstract List<T> ReadAllFromDataSource();

    /// <summary>
    /// This method should save all the given data to persistent storage.
    /// The specific way to do this must be implemented in a derived class.
    /// </summary>
    /// <param name="elements">List of objects of type T, to save to persistent storage</param>
    protected abstract void SaveAllToDataSource(List<T> elements);
}

