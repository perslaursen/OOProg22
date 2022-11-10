using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Order
{
    public class CreateOrderModel : PageModel
    {
        private IOrderRepository _orderRepo;
        private ICustomerRepository _customerRepo;

        public CreateOrderModel(IOrderRepository orderRepo, ICustomerRepository customerRepo)
        {
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
        }

        [BindProperty]
        public string OrderRemark { get; set; }

        [BindProperty]
        public int? CustomerId { get; set; }

        public Models.Customer Customer { get; set; }

        public IActionResult OnGet(int custId)
        {
            Customer = _customerRepo.Read(custId) ?? new Models.Customer();
            CustomerId = custId;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (CustomerId.HasValue)
            {
                Models.Customer? customer = _customerRepo.Read(CustomerId.Value);
                Models.Order newOrder = new Models.Order(0, customer) { Remark = OrderRemark };
                int orderId = _orderRepo.Create(newOrder).Id;

                return RedirectToPage("EditOrder", new { id = orderId });
            }

            return RedirectToPage("GetAllOrders");
        }
    }
}
