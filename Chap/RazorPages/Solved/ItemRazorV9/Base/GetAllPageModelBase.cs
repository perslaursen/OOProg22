using ItemRazorV1.Service.Repositories.Interfaces;

namespace ItemRazorV1.Base
{
    public class GetAllPageModelBase<TData, TRepo> : PageModelAppBase<TRepo>
        where TData : class, IHasId, IUpdateFromOther<TData>
        where TRepo : IRepository<TData>
    {
        public List<TData> Data { get; protected set; }

        public GetAllPageModelBase(TRepo repository) : base(repository) { }

        public virtual void OnGet()
        {
            Data = _repository.GetAll().ToList();
        }
    }
}
