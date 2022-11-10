using ItemRazorV1.Service.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItemRazorV1.Base
{
    public class EditPageModelBase<TData, TRepo> : PageModelAppBase<TRepo>
        where TData : class, IHasId, IUpdateFromOther<TData>
        where TRepo : IRepository<TData>
    {
        private string _onPostRedirectPage;

        [BindProperty]
        public TData Data { get; set; }

        public EditPageModelBase(TRepo repository, string onPostRedirectPage) : base(repository)
        {
            _onPostRedirectPage = onPostRedirectPage;
        }

        public IActionResult OnGet(int id)
        {
            TData? data = _repository.Read(id);

            if (data == null)
                return RedirectToPage("/NotFound");

            Data = data;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Update(Data.Id, Data);

            return RedirectToPage(_onPostRedirectPage);
        }
    }
}
