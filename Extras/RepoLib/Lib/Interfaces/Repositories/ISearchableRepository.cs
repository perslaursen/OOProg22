
/// <summary>
/// Interface for a searchable repository. 
/// Objects are stored as key/value pairs.
/// A numerical id is used as key, so stored objects are required to implement IHasId.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository.</typeparam>
public interface ISearchableRepository<T> where T : IHasId
{
    /// <summary>
    /// Returns all objects which match a string-based search term.
    /// </summary>
    /// <param name="searchTerm">Search term against which objects are matched.</param>
    /// <returns>List of all objects matching the search term</returns>
    List<T> Search(string searchTerm);
}

