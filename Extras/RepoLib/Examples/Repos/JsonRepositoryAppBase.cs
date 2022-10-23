
/// <summary>
/// Base class for JSON-based repositories in this application.
/// Main purpose is to store absolute path in a single location.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository.</typeparam>
public abstract class JsonRepositoryAppBase<T> : JsonRepositoryBase<T>
    where T : IHasId
{
    protected const string FileLocation = @"..\..\..\Examples\Data\";

    public JsonRepositoryAppBase(string jsonFileNameShort, bool loadOnCreation = true) 
        : base(FileLocation + jsonFileNameShort, loadOnCreation)
    {
    }
}
