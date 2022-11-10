using ItemRazorV1.Service.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItemRazorV1.Base
{
    public class CreatePageModelBase<TData, TRepo> : PageModelAppBase<TRepo>
        where TData : class, IHasId, IUpdateFromOther<TData>
        where TRepo : IRepository<TData>
    {
        private string _onPostRedirectPage;

        [BindProperty]
        public TData Data { get; set; }

        public CreatePageModelBase(TRepo repository, string onPostRedirectPage) : base(repository)
        {
            _onPostRedirectPage = onPostRedirectPage;
        }

        public virtual IActionResult OnGet()
        {
            return Page();
        }

        public virtual IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Create(Data);

            return RedirectToPage(_onPostRedirectPage);
        }
    }
}
