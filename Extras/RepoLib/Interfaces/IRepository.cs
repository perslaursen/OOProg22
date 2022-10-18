
public interface IRepository<T> where T : IHasId
{
    int Create(T t, int? hardId);
    T? Read(int id);
    bool Update(int id, T t);
    bool Delete(int id);

    List<T> GetAll();
    Dictionary<int, T> GetAllAsDictionary();
    void Clear();

    List<T> Search(string searchTerm);
    void InitFromList(List<T> elements, bool useIds);
}
