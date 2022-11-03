namespace ItemRazorV1.Service.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, IHasId, IUpdateFromOther<T>
    {
        int Count { get; }

        IEnumerable<T> GetAll();
        T Create(T t);
        T? Read(int id);
        void Update(int id, T t);
        T? Delete(int id);
        IEnumerable<T> Search(string str);
    }
}
