
/// <summary>
/// Interface for a CRUD+ repository, capable of storing objects of type T. 
/// Note that T itself must be a class type, and implement the interface IId.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository</typeparam>
public interface IRepository<T> where T : class, IId
{
    /// <summary>
    /// Create a new object of type T. The Id for the new object 
    /// will be set on the object itself, in the Id property.
    /// </summary>
    T Create();

    /// <summary>
    /// Read the object identified by the given Id.
    /// If no such object is found, null is returned.
    /// </summary>
    T? Read(int id);

    /// <summary>
    /// Delete the object identified by the given Id.
    /// The return value indicates if an object was deleted or not.
    /// </summary>
    bool Delete(int id);

    /// <summary>
    /// Update the object identified by the Id on the given object.
    /// The existing object is replaced by the provided object.
    /// </summary>
    void Update(T t);

    /// <summary>
    /// Get all objects currently stored in the repository
    /// </summary>
    List<T> GetAll();

    /// <summary>
    /// Get all objects which match the given search term.
    /// </summary>
    List<T> Search(string searchTerm);
}
