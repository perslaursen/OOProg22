using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageEFCDemo.Data;

namespace RazorPageEFCDemo.Pages.Order
{
    public class EditModel : PageModel
    {
        private readonly EFCDemoContext _context;

        public EditModel(EFCDemoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order =  await _context.Orders.FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            Order = order;
           ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "ID");
           ViewData["ItemID"] = new SelectList(_context.Items, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.ID == id);
        }
    }
}
