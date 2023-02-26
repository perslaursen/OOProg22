using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageADODemo.Services.Repositories.General.Interfaces;

namespace RazorPageADODemo.Pages.Base
{
    public class PageModelAppBase<T> : PageModel where T : class, IHasId
    {
        protected IRepository<T> _repository;
        protected string _onPostRedirectPage;

        [BindProperty]
        public T Data { get; set; } = null!;

        public PageModelAppBase(IRepository<T> repository, string onPostRedirectPage)
        {
            _repository = repository;
            _onPostRedirectPage = onPostRedirectPage;
        }
    }
}
