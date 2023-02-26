using Microsoft.AspNetCore.Mvc;
using RazorPageEFCDemo.Services.Repositories.General.Interfaces;

namespace RazorPageEFCDemo.Pages.Base
{
    public class CreatePageModel<T> : PageModelAppBase<T> where T : class, IHasID, IUpdateFromOther<T>
    {
        public CreatePageModel(IRepository<T> repository, string onPostRedirectPage)
            : base(repository, onPostRedirectPage)
        {
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
