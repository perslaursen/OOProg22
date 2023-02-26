using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class DeleteModel : PageModel
    {
        private IItemRepository _repository;

        public DeleteModel(IItemRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Models.Item Data { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Models.Item data = _repository.Read(id.Value);

            if (data == null)
            {
                return NotFound();
            }
            else 
            {
                Data = data;
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            _repository.Delete(Data.ID);

            return RedirectToPage("./Index");
        }
    }
}
