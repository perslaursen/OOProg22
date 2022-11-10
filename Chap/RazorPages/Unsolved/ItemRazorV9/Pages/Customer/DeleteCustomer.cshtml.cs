using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {
        private ICustomerRepository _repo;

        public DeleteCustomerModel(ICustomerRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Models.Customer Customer { get; set; }


        public IActionResult OnGet(int id)
        {
            Models.Customer? customer = _repo.Read(id);

            if (customer != null)
                Customer = customer;
            else
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Customer? deletedCustomer = _repo.Delete(Customer.Id);
            if (deletedCustomer == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return RedirectToPage("GetAllCustomers");
        }
    }
}
