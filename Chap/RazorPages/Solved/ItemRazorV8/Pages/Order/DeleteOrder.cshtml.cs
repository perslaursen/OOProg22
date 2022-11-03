using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Order
{
    public class DeleteOrderModel : PageModel
    {
        private IOrderRepository _repo;

        public DeleteOrderModel(IOrderRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Models.Order Order { get; set; }


        public IActionResult OnGet(int id)
        {
            Models.Order? order = _repo.Read(id);

            if (order != null)
                Order = order;
            else
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Order? deletedOrder = _repo.Delete(Order.Id);
            if (deletedOrder == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return RedirectToPage("GetAllOrders");
        }
    }
}
