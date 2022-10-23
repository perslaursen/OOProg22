
/// <summary>
/// Interface for any data source that can be "loaded" and "saved" in a meaningful way.
/// </summary>
public interface IPersistentDataSource
{
    void Load();
    void Save();
}
