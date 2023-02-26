using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RazorPageEFCDemo.Services.Repositories.General.Interfaces;

namespace RazorPageEFCDemo.Pages.Base
{
    public class PageModelAppBase<T> : PageModel where T : class, IHasID, IUpdateFromOther<T>
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
