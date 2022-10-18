
public interface IDataSource<T> where T : IHasId
{
    void Load();
    void Save();
}
