using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageEFCDemo.Data;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class EditModel : PageModel
    {
        private IItemRepository _repository;

        public EditModel(IItemRepository repository)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Update(Data.ID, Data);

            return RedirectToPage("./Index");
        }
    }
}
