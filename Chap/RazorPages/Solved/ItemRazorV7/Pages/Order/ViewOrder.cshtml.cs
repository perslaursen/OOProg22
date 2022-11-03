using ItemRazorV1.Models;
using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItemRazorV1.Pages.Order
{
    public class ViewOrderModel : PageModel
    {
        private IOrderService _orderService;
        private IItemService _itemService;

        public ViewOrderModel(IOrderService orderService, IItemService itemService)
        {
            _orderService = orderService;
            _itemService = itemService;

            List<Models.Item> items = _itemService.GetItems();
            ItemList = items.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() }).ToList();
        }

        [BindProperty]
        public Models.Order Order{ get; set; }


        [BindProperty]
        public string ChosenItem{ get; set; }

        public List<SelectListItem> ItemList { get; set; }

        public IActionResult OnGet(int id)
        {
            Order = _orderService.GetOrder(id);
            if (Order == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostDecrease(int itemId, int orderId)
        {
            Order = _orderService.GetOrder(orderId);
            Models.Order updOrder = CloneOrder(Order);
            OrderLine? chosenOrderLine = updOrder.GetOrderLine(itemId);

            if (chosenOrderLine != null)
            {
                chosenOrderLine.Amount--;

                if (chosenOrderLine.Amount == 0)
                    updOrder.Items.Remove(chosenOrderLine);
            }

            _orderService.UpdateOrder(updOrder);

            Order = _orderService.GetOrder(orderId);

            return Page();
        }

        public IActionResult OnPostIncrease(int itemId, int orderId)
        {
            Order = _orderService.GetOrder(orderId);
            Models.Order updOrder = CloneOrder(Order);
            OrderLine? chosenOrderLine = updOrder.GetOrderLine(itemId);

            if (chosenOrderLine != null)
                chosenOrderLine.Amount++;
            else
            {
                Models.Item chosenItem = _itemService.GetItem(itemId);
                updOrder.Items.Add(new OrderLine(chosenItem, 1));
            }

            _orderService.UpdateOrder(updOrder);

            Order = _orderService.GetOrder(orderId);

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
