using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class DeleteItemModel : PageModel
    {
        private IItemService _itemService;

        public DeleteItemModel(IItemService itemService)
        {
            _itemService = itemService;
        }

        [BindProperty]
        public Models.Item Item { get; set; }


        public IActionResult OnGet(int id)
        {
            Item = _itemService.GetItem(id);
            if (Item == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Item deletedItem = _itemService.DeleteItem(Item.Id);
            if (deletedItem == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return RedirectToPage("GetAllItems");
        }
    }
}
