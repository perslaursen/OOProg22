
/// <summary>
/// Interface for a persistent repository. 
/// This is just a convenient aggregation of other interfaces.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository.</typeparam>
public interface IPersistentRepository<T> : 
    IRepository<T>, 
    IPersistentDataSource 
    where T : IHasId
{
}

