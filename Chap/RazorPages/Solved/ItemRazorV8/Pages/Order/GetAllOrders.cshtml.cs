using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Order
{
    public class GetAllOrdersModel : PageModel
    {
        private IOrderRepository _repo;

        public GetAllOrdersModel(IOrderRepository repo)
        {
            _repo = repo;
            CustomerSearchString = "";
        }

        public List<Models.Order>? Orders { get; private set; }

        [BindProperty]
        public string CustomerSearchString { get; set; }

        public void OnGet()
        {
            Orders = _repo.GetAll().ToList();
        }

        public IActionResult OnPostCustomerNameSearch()
        {
            Orders = _repo.Search(CustomerSearchString).ToList();
            return Page();
        }
    }
}
