using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class CreateModel : PageModel
    {
        private IItemRepository _repository;

        public CreateModel(IItemRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Item Data { get; set; }
        

        public IActionResult OnPost()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Create(Data);

            return RedirectToPage("./Index");
        }
    }
}
