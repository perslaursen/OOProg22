using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class CreateItemModel : PageModel
    {
        private IItemRepository _repo;

        public CreateItemModel(IItemRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Models.Item Item { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Create(Item);
            return RedirectToPage("GetAllItems");
        }
    }
}
