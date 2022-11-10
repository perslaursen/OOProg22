using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Base
{
    public class PageModelAppBase<TRepo> : PageModel
    {
        protected TRepo _repository;

        public PageModelAppBase(TRepo repository)
        {
            _repository = repository;
        }      
    }
}
