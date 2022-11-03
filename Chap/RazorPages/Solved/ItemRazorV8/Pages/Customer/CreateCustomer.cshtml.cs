using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Customer
{
    public class CreateCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        public CreateCustomerModel( ICustomerRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Models.Customer Customer{ get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Create(Customer);
            return RedirectToPage("GetAllCustomers");
        }
    }
}
