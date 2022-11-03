using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class GetAllItemsModel : PageModel
    {
        private IItemService _itemService;

        public GetAllItemsModel(IItemService itemService)
        {
            _itemService = itemService;
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
            Items = _itemService.GetItems();
        }

        public IActionResult OnPostNameSearch()
        {
            Items = _itemService.NameSearch(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostPriceFilter()
        {
            Items = _itemService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
