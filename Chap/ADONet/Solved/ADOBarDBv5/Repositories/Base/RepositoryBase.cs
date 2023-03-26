
/// <summary>
/// Base class for an implementation of the IRepository interface,
/// by means of an DBMethodsBase implementation for the data type in question.
/// </summary>
/// <typeparam name="T">Type of objects managed by repository</typeparam>
public class RepositoryBase<T> : IRepository<T> where T : class, IHasId
{
    private DBMethodsBase<T> _dbMethods;

    public RepositoryBase(DBMethodsBase<T> dbMethods)
    {
        _dbMethods = dbMethods;
    }

    public int Create(T t)
    {
        int id = NextId();
        t.Id = id;

        _dbMethods.WriteToDB(t);
        return id;
    }

    public bool Delete(int id)
    {
        return _dbMethods.DeleteFromDB(id) > 0;
    }

    public List<T> GetAll()
    {
        return _dbMethods.ReadAllFromDB();
    }

    public T? Read(int id)
    {
        return _dbMethods.ReadAllFromDB($"Id = {id}").FirstOrDefault();
    }

    public int NextId()
    {
        return GetAll().Select(t => t.Id).DefaultIfEmpty(0).Max() + 1;
    }
}
