using ItemRazorV1.Models;
using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItemRazorV1.Pages.Order
{
    public class ViewOrderModel : PageModel
    {
        private IOrderRepository _orderRepo;
        private IItemRepository _itemRepo;

        public ViewOrderModel(IOrderRepository orderRepo, IItemRepository itemRepo)
        {
            _orderRepo = orderRepo;
            _itemRepo = itemRepo;

            ItemList = _itemRepo.GetAll().Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() }).ToList();
        }

        [BindProperty]
        public Models.Order Order { get; set; }


        [BindProperty]
        public string ChosenItem{ get; set; }

        public List<SelectListItem> ItemList { get; set; }

        public IActionResult OnGet(int id)
        {
            Models.Order? order = _orderRepo.Read(id);

            if (order != null)
                Order = order;
            else
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostDecrease(int itemId, int orderId)
        {
            Order = _orderRepo.Read(orderId);

            Models.Order updOrder = CloneOrder(Order);
            OrderLine? chosenOrderLine = updOrder.GetOrderLine(itemId);

            if (chosenOrderLine != null)
            {
                chosenOrderLine.Amount--;

                if (chosenOrderLine.Amount == 0)
                    updOrder.Items.Remove(chosenOrderLine);
            }

            _orderRepo.Update(updOrder.Id, updOrder);

            Order = _orderRepo.Read(orderId);

            return Page();
        }

        public IActionResult OnPostIncrease(int itemId, int orderId)
        {
            Order = _orderRepo.Read(orderId);

            Models.Order updOrder = CloneOrder(Order);
            OrderLine? chosenOrderLine = updOrder.GetOrderLine(itemId);

            if (chosenOrderLine != null)
                chosenOrderLine.Amount++;
            else
            {
                Models.Item chosenItem = _itemRepo.Read(itemId);
                updOrder.Items.Add(new OrderLine(chosenItem, 1));
            }

            _orderRepo.Update(updOrder.Id, updOrder);

            Order = _orderRepo.Read(orderId);

            return Page();
        }

        public IActionResult OnPostAdd(int orderId)
        {
            return OnPostIncrease(int.Parse(ChosenItem ?? "0"), orderId);
        }

        private Models.Order CloneOrder(Models.Order order)
        {
            Models.Order clone = new Models.Order(order.Id, order?.Customer);
            clone.Remark = order?.Remark;
            clone.Items = new List<OrderLine>(order?.Items ?? new List<OrderLine>());

            return clone;
        }
    }
}
