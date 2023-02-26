using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageEFCDemo.Data;

namespace RazorPageEFCDemo.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly EFCDemoContext _context;

        public DetailsModel(EFCDemoContext context)
        {
            _context = context;
        }

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
    }
}
