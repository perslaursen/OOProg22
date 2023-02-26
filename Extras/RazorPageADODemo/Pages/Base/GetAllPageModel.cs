using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageADODemo.Services.Repositories.General.Interfaces;

namespace RazorPageADODemo.Pages.Base
{
    public class GetAllPageModel<T> : PageModel where T : class, IHasId
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
