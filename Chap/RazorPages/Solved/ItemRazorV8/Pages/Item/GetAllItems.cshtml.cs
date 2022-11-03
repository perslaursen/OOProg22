using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class GetAllItemsModel : PageModel
    {
        private IItemRepository _repo;

        public GetAllItemsModel(IItemRepository repo)
        {
            _repo = repo;
            SearchString = "";
        }

        public List<Models.Item>? Items { get; private set; }

        [BindProperty] 
        public string SearchString { get; set; }

        [BindProperty]
        public int MinPrice { get; set; }

        [BindProperty]
        public int MaxPrice { get; set; }


        public void OnGet()
        {
            Items = _repo.GetAll().ToList();
        }

        public IActionResult OnPostNameSearch()
        {
            Items = _repo.Search(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostPriceFilter()
        {
            Items = _repo.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
