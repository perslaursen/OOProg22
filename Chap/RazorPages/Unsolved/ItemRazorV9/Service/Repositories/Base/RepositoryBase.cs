using ItemRazorV1.Service.Repositories.Interfaces;

namespace ItemRazorV1.Service.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IHasId, IUpdateFromOther<T>
    {
        protected Dictionary<int, T> _data;
        protected IJsonFileRepository<T> _jsonRepo;

        public RepositoryBase(IJsonFileRepository<T> jsonRepo)
        {
            _jsonRepo = jsonRepo;
            _data = Load();
        }

        public int Count { get { return _data.Count; } }

        public T Create(T t)
        {
            t.Id = NextId();
            _data[t.Id] = t;

            Save();

            return t;
        }

        public T? Read(int id)
        {
            return _data.ContainsKey(id) ? _data[id] : null;
        }

        public void Update(int id, T t)
        {
            if (t != null && _data.ContainsKey(id))
            {
                _data[id].Update(t);
                Save();
            }
        }

        public T? Delete(int id)
        {
            T? toBeDeleted = Read(id);

            if (toBeDeleted != null)
            {
                _data.Remove(id);
                Save();
            }

            return toBeDeleted;
        }

        public IEnumerable<T> GetAll()
        {
            return _data.Values.OrderBy(t => t.Id);
        }

        public IEnumerable<T> Search(string str)
        {
            return GetAll().Where(t => SearchMatch(t, str));
        }


        protected abstract bool SearchMatch(T t, string str);


        private int NextId()
        {
            return Count > 0 ? GetAll().Select(t => t.Id).Max() + 1 : 1;
        }

        private Dictionary<int, T> Load()
        {
            return _jsonRepo.GetFromJsonFile().ToDictionary(t => t.Id, t => t);
        }

        private void Save()
        {
            _jsonRepo.SaveToJsonFile(_data.Values);
        }
    }
}
