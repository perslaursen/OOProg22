
/// <summary>
/// Base class for a repository using file-based persistent storage.
/// Data is stored in JSON format.
/// </summary>
/// <typeparam name="T">Type of objects stored in the repository.</typeparam>
public abstract class JsonRepositoryBase<T> : PersistentRepositoryBase<T> 
    where T : IHasId
{
    public JsonRepositoryBase(string jsonFileName, bool loadOnCreation = true) 
        : base(loadOnCreation)    
    {
        JsonFileName = jsonFileName;
    }

    protected string JsonFileName { get; }

    protected override List<T> ReadAllFromDataSource()
    {
        return JsonFileReader<T>.ReadJson(JsonFileName);
    }

    protected override void SaveAllToDataSource(List<T> elements)
    {
        JsonFileWriter<T>.WriteToJson(elements, JsonFileName);
    }
}
