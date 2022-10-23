
/// <summary>
/// Interface for a "mockable" repository, where a set of "mock data" can be filled into
/// the repository by an external client.
/// Objects are stored as key/value pairs.
/// A numerical id is used as key, so stored objects are required to implement IHasId.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository.</typeparam>
public interface IMockableRepository<T> where T : IHasId
{
    /// <summary>
    /// Initializes the Repository with objects from the provided list.
    /// This can e.g. be used to load the Repository with mock data.
    /// </summary>
    /// <param name="elements">Objects to load into the Repository</param>
    /// <param name="useIds">
    /// If true, the ids on the objects are used as identifiers. 
    /// If false, the Repository will generate ids for the objects.
    /// </param>
    void InitFromList(List<T> elements, bool useIds);
}
