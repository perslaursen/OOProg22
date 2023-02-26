using Microsoft.AspNetCore.Mvc;
using RazorPageADODemo.Services.Repositories.General.Interfaces;

namespace RazorPageADODemo.Pages.Base
{
    public class DeletePageModel<T> : PageModelAppBase<T> where T : class, IHasId
    {
        public DeletePageModel(IRepository<T> repository, string onPostRedirectPage) 
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
            _repository.Delete(Data.ID);

            return RedirectToPage(_onPostRedirectPage);
        }
    }
}
