
public abstract class RepositoryWithDataSourceBase<T> : RepositoryBase<T>, IDataSource<T> where T : IHasId
{
    public RepositoryWithDataSourceBase(bool loadOnCreation = true)
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

    public void Load()
    {
        InitFromList(ReadAllFromDataSource());
    }

    public void Save()
    {
        SaveAllToDataSource(GetAll());
    }

    protected abstract void UpdateObject(T tEx, T tNew);
    protected abstract List<T> ReadAllFromDataSource();
    protected abstract void SaveAllToDataSource(List<T> elements);
}

