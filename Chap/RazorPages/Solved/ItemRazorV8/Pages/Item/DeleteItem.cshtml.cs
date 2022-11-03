using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class DeleteItemModel : PageModel
    {
        private IItemRepository _repo;

        public DeleteItemModel(IItemRepository repo)
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
            Models.Item? deletedItem = _repo.Delete(Item.Id);
            if (deletedItem == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return RedirectToPage("GetAllItems");
        }
    }
}
