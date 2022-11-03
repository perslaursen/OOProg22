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

        public void OnGet()
        {
            Items = _itemService.GetItems();
        }
    }
}
