using ItemRazorV1.Models;
using ItemRazorV1.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ItemRazorV1.Pages.Order
{
    public class EditOrderModel : PageModel
    {
        private IOrderService _orderService;
        private IItemService _itemService;

        public EditOrderModel(IOrderService orderService, IItemService itemService)
        {
            _orderService = orderService;
            _itemService = itemService;

            List<Models.Item> selectableItems = _itemService.GetItems();
            ItemList = new SelectList(selectableItems, nameof(Models.Item.Id), nameof(Models.Item.Name));
        }

        public int OrderId => Order?.Id ?? 0;

        [BindProperty]
        public Models.Order Order { get; set; }


        [BindProperty]
        public int ChosenItemId { get; set; }

        public SelectList ItemList { get; set; }

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

        public IActionResult OnPostDecrease(int itemId)
        {
            Order = _orderService.GetOrder(OrderId);
            Models.Order updOrder = CloneOrder(Order);
            OrderLine? chosenOrderLine = updOrder.GetOrderLine(itemId);

            if (chosenOrderLine != null)
            {
                chosenOrderLine.Amount--;

                if (chosenOrderLine.Amount == 0)
                    updOrder.Items.Remove(chosenOrderLine);
            }

            _orderService.UpdateOrder(updOrder);

            Order = _orderService.GetOrder(OrderId);

            return Page();
        }

        public IActionResult OnPostIncrease(int itemId)
        {
            Order = _orderService.GetOrder(OrderId);
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

            Order = _orderService.GetOrder(OrderId);

            return Page();
        }

        public IActionResult OnPostAdd()
        {
            return OnPostIncrease(ChosenItemId);
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
