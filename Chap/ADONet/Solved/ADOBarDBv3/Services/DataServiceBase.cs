
/// <summary>
/// Base class for an implementation of the IDataService interface,
/// by means of a DbMethods instance for the data type in question.
/// </summary>
/// <typeparam name="T">Type of objects managed by data service</typeparam>
public abstract class DataServiceBase<T> : IDataService<T> where T : class, IHasId
{
    protected DBMethodsBase<T> _dbMethods;

    public DataServiceBase(DBMethodsBase<T> dbMethods)
    {
        _dbMethods = dbMethods;
    }

    #region Implementation of IService interface
    
    public int Create(T t)
    {
        int id = NextId();
        t.Id = id;

        _dbMethods.WriteToDB(t);
        return id;
    }

    public T? Read(int id)
    {
        return _dbMethods.ReadAllFromDB($"Id = {id}").FirstOrDefault();
    }

    public bool Delete(int id)
    {
        return _dbMethods.DeleteFromDB(id) > 0;
    }

    public List<T> GetAll()
    {
        return _dbMethods.ReadAllFromDB();
    }

    #endregion

    private int NextId()
    {
        return GetAll().Select(dr => dr.Id).DefaultIfEmpty(0).Max() + 1;
    }
}
