using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageEFCDemo.Data;

namespace RazorPageEFCDemo.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly EFCDemoContext _context;

        public DeleteModel(EFCDemoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.ID == id);

            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                Customer = customer;
                _context.Customers.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
