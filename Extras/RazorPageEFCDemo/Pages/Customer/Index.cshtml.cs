using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageEFCDemo.Data;

namespace RazorPageEFCDemo.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly EFCDemoContext _context;

        public IndexModel(EFCDemoContext context)
        {
            _context = context;
        }

        public IList<Models.Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Customer = await _context.Customers.ToListAsync();
            }
        }
    }
}
