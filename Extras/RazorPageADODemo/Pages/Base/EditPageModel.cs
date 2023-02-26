using Microsoft.AspNetCore.Mvc;
using RazorPageADODemo.Services.Repositories.General.Interfaces;

namespace RazorPageADODemo.Pages.Base
{
    public class EditPageModel<T> : PageModelAppBase<T> where T : class, IHasId
    {
        public EditPageModel(IRepository<T> repository, string onPostRedirectPage) 
            : base(repository, onPostRedirectPage)
        {
        }

        public virtual IActionResult OnGet(int id)
        {
            T? data = _repository.Read(id);

            if (data == null)
                return RedirectToPage("/Error");

            Data = data;
            return Page();
        }

        public virtual IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Update(Data.ID, Data);

            return RedirectToPage(_onPostRedirectPage);
        }
    }
}
