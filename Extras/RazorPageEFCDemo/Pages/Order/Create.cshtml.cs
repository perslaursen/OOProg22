using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageEFCDemo.Data;

namespace RazorPageEFCDemo.Pages.Order
{
    public class CreateModel : PageModel
    {
        private readonly EFCDemoContext _context;

        public CreateModel(EFCDemoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "ID");
        ViewData["ItemID"] = new SelectList(_context.Items, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Models.Order Order { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
