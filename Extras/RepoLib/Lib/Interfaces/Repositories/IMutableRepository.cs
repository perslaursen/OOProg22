
/// <summary>
/// Interface for a "mutable" repository, where an external client can alter the stored data.
/// The client can create, update and delete individual objects, and can clear the entire repository.
/// Objects are stored as key/value pairs.
/// A numerical id is used as key, so stored objects are required to implement IHasId.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository.</typeparam>
public interface IMutableRepository<T> where T : IHasId
{
    /// <summary>
    /// Adds the object t to the Repository. In that sense, the naming "Create" is not entirely accurate,
    /// but is chosen to conform to the CRUD acronym. If hardId is set, the object will be stored with this id,
    /// otherwise the Repository will generate and apply a new id.
    /// </summary>
    /// <param name="t">Object to add to Repository</param>
    /// <param name="hardId">If set, the new object is stored using this id</param>
    /// <returns>Id for the added object</returns>
    int Create(T t, int? hardId);

    /// <summary>
    /// Updates the object identified by the given id, with the data provided in the given object.
    /// </summary>
    /// <param name="id">Id for object to update</param>
    /// <param name="t">Object holding updated data</param>
    /// <returns>Whether or not the update was carried out</returns>
    bool Update(int id, T t);

    /// <summary>
    /// Deletes the object identified by the given id.
    /// </summary>
    /// <param name="id">Id for object to delete</param>
    /// <returns>Whether or not the deletion was carried out</returns>
    bool Delete(int id);

    /// <summary>
    /// Clears all objects from the Repository.
    /// </summary>
    void Clear();
}
