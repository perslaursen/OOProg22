using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class EditItemModel : PageModel
    {
        private IItemService _itemService;

        public EditItemModel(IItemService itemService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _itemService.UpdateItem(Item);
            return RedirectToPage("GetAllItems");
        }
    }
}
