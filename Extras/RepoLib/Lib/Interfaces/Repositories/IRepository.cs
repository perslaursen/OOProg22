
/// <summary>
/// Interface for a repository with full functionality (CRUD and more). 
/// Objects are stored as key/value pairs.
/// A numerical id is used as key, so stored objects are required to implement IHasId.
/// As such, this is just a convenient aggregation of other interfaces.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository.</typeparam>
public interface IRepository<T> : 
    IReadOnlyRepository<T>, 
    IMutableRepository<T>, 
    ISearchableRepository<T>, 
    IMockableRepository<T> where T : IHasId
{
}
