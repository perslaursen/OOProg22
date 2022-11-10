using ItemRazorV1.Service.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItemRazorV1.Base
{
    public class DeletePageModelBase<TData, TRepo> : PageModelAppBase<TRepo>
        where TData : class, IHasId, IUpdateFromOther<TData>
        where TRepo : IRepository<TData>
    {
        private string _onPostRedirectPage;

        [BindProperty]
        public TData Data { get; set; }

        public DeletePageModelBase(TRepo repository, string onPostRedirectPage) 
            : base(repository)
        {
            _onPostRedirectPage = onPostRedirectPage;
        }

        public virtual IActionResult OnGet(int id)
        {
            TData? data = _repository.Read(id);

            if (data == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            Data = data;
            return Page();
        }

        public IActionResult OnPost()
        {
            TData? deletedData = _repository.Delete(Data.Id);

            if (deletedData == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return RedirectToPage(_onPostRedirectPage);
        }
    }
}
