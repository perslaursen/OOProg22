
/// <summary>
/// Interface for a read-only repository. 
/// Objects are stored as key/value pairs.
/// A numerical id is used as key, so stored objects are required to implement IHasId.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository.</typeparam>
public interface IReadOnlyRepository<T> where T : IHasId
{
    /// <summary>
    /// Reads the object identified by the given id. Null is returned if no such object is found.
    /// </summary>
    /// <param name="id">Id for object to read</param>
    /// <returns>Object with given id, or null if no such object is found</returns>
    T? Read(int id);

    /// <summary>
    /// Returns a List of objects stored in the Repository.
    /// </summary>
    /// <returns>List of all objects stored in the Repository</returns>
    List<T> GetAll();

    /// <summary>
    /// Returns a Dictionary of all keys/objects stored in the Repository.
    /// </summary>
    /// <returns>
    /// Dictionary of all objects stored in the Repository. 
    /// Keys holds all identifiers for the objects.
    /// Values holds the objects themselves.
    /// </returns>
    Dictionary<int, T> GetAllAsDictionary();
}
