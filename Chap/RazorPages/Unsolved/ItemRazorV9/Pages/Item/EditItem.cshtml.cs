using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class EditItemModel : PageModel
    {
        private IItemRepository _repo;

        public EditItemModel(IItemRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Models.Item Item { get; set; }

        public IActionResult OnGet(int id)
        {
            Models.Item? item = _repo.Read(id);

            if (item != null)
                Item = item;
            else
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Update(Item.Id, Item);
            return RedirectToPage("GetAllItems");
        }
    }
}
