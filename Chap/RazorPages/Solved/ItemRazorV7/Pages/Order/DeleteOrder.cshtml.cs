using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Order
{
    public class DeleteOrderModel : PageModel
    {
        private IOrderService _orderService;

        public DeleteOrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public Models.Order Order{ get; set; }


        public IActionResult OnGet(int id)
        {
            Order = _orderService.GetOrder(id);
            if (Order == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Order deletedOrder = _orderService.DeleteOrder(Order.Id);
            if (deletedOrder == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return RedirectToPage("GetAllOrders");
        }
    }
}
