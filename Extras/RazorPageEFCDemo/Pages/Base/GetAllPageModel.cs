using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageEFCDemo.Services.Repositories.General.Interfaces;

namespace RazorPageEFCDemo.Pages.Base
{
    public class GetAllPageModel<T> : PageModel where T : class, IHasID, IUpdateFromOther<T>
    {
        private IRepository<T> _repository;

        public List<T> Data { get; protected set; }

        public GetAllPageModel(IRepository<T> repository)
        {
            _repository = repository;
            Data = new List<T>();
        }

        public virtual void OnGet()
        {
            Data = _repository.GetAll().ToList();
        }
    }
}
