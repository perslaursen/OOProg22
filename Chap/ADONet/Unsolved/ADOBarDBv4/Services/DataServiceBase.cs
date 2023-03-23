
/// <summary>
/// Base class for an implementation of the IDataService interface,
/// by means of an IRepository implementation for the data type in question.
/// Can be used when the mapping from repository to data service is trivial.
/// </summary>
/// <typeparam name="T">Type of objects managed by data service</typeparam>
public abstract class DataServiceBase<T> : IDataService<T> where T : class, IHasId
{
    protected IRepository<T> _repository;

    public DataServiceBase(IRepository<T> repository)
    {
        _repository = repository;
    }

    #region Implementation of IService interface

    public int Create(T t)
    {
        int newId = _repository.Create(t);
        t.Id = newId;
        return newId;
    }

    public T? Read(int id)
    {
        return _repository.Read(id);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }

    public List<T> GetAll()
    {
        return _repository.GetAll();
    }

    #endregion
}
