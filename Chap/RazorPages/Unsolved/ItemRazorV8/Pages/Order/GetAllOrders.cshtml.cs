using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Order
{
    public class GetAllOrdersModel : PageModel
    {
        private IOrderService _orderService;

        public GetAllOrdersModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<Models.Order>? Orders { get; private set; }

        [BindProperty]
        public string CustomerSearchString { get; set; }

        public void OnGet()
        {
            Orders = _orderService.GetOrders();
        }

        public IActionResult OnPostCustomerNameSearch()
        {
            Orders = _orderService.CustomerNameSearch(CustomerSearchString).ToList();
            return Page();
        }
    }
}
