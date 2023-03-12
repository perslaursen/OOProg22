
public interface IChainedCollection<T> where T : IHasId
{
    /// <summary>
    /// Returns the first chain link in the collection.
    /// If the collection is empty, null is returned.
    /// </summary>
    ChainLink<T>? Start { get; }

    /// <summary>
    /// Returns the last chain link in the collection.
    /// If the collection is empty, null is returned.
    /// </summary>
    ChainLink<T>? End { get; }

    /// <summary>
    /// Returns the number of objects stored in the collection
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Returns whether or not the collection is empty
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    /// Adds an object to the end of the collection
    /// </summary>
    void AddEnd(T value);

    /// <summary>
    /// Adds an object to the start of the collection
    /// </summary>
    void AddStart(T value);

    /// <summary>
    /// Returns a List containing all the objects stored in the collection
    /// </summary>
    List<T> GetAll();

    /// <summary>
    /// Return the object with the given id. 
    /// If no such object is found, null is returned.
    /// </summary>
    T? Read(int id);
}