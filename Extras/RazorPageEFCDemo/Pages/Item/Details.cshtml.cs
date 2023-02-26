using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class DetailsModel : PageModel
    {
        private IItemRepository _repository;

        public DetailsModel(IItemRepository repository)
        {
            _repository = repository;
        }

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
    }
}
