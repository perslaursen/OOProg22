using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Customer
{
    public class GetAllCustomersModel : PageModel
    {
        private ICustomerService _customerService;

        public GetAllCustomersModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public List<Models.Customer>? Customers { get; private set; }

        [BindProperty]
        public string SearchString { get; set; }

        public void OnGet()
        {
            Customers = _customerService.GetCustomers();
        }

        public IActionResult OnPostNameSearch()
        {
            Customers = _customerService.NameSearch(SearchString).ToList();
            return Page();
        }
    }
}
