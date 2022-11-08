using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Order
{
    public class CreateOrderModel : PageModel
    {
        private IOrderService _orderService;
        private ICustomerService _customerService;

        public CreateOrderModel(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        [BindProperty]
        public string OrderRemark { get; set; }

        [BindProperty]
        public int? CustomerId { get; set; }

        public Models.Customer Customer { get; set; }

        public IActionResult OnGet(int custId)
        {
            Customer = _customerService.GetCustomer(custId);
            CustomerId = custId;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (CustomerId.HasValue)
            {
                Models.Customer customer = _customerService.GetCustomer(CustomerId.Value);

                List<Models.Order> orders = _orderService.GetOrders();
                int orderId = orders.Count == 0 ? 1 : orders.Select(o => o.Id).Max() + 1;

                Models.Order newOrder = new Models.Order(orderId, customer);
                newOrder.Remark = OrderRemark;

                _orderService.AddOrder(newOrder);

                return RedirectToPage("EditOrder", new { id = orderId });
            }

            return RedirectToPage("GetAllOrders");
        }
    }
}
