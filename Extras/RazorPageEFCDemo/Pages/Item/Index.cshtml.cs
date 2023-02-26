using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class IndexModel : PageModel
    {
        private IItemRepository _repository;

        public IndexModel(IItemRepository repository)
        {
            _repository = repository;
        }

        public IList<Models.Item> Data { get;set; } = default!;

        public void OnGet()
        {
            Data = _repository.GetAll().ToList();
        }
    }
}
