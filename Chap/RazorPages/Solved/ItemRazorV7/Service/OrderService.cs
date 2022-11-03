using ItemRazorV1.MockData;
using ItemRazorV1.Models;

namespace ItemRazorV1.Service
{
    public class OrderService : IOrderService
    {
        private List<Order> _orders;

        private JsonFileOrderService JsonFileOrderService { get; set; }

        public OrderService(JsonFileOrderService jsonFileOrderService)
        {
            JsonFileOrderService = jsonFileOrderService;
            // _orders = MockOrders.GetMockOrders();
            _orders = JsonFileOrderService.GetJsonOrders().ToList();
        }

        public OrderService()
        {
            _orders = MockOrders.GetMockOrders();
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
            JsonFileOrderService.SaveJsonOrders(_orders);
        }

        public Order GetOrder(int id)
        {
            foreach (Order order in _orders)
            {
                if (order.Id == id)
                    return order;
            }

            return null;
        }

        public void UpdateOrder(Order order)
        {
            if (order != null)
            {
                foreach (Order o in _orders)
                {
                    if (o.Id == order.Id)
                    {
                        o.Customer = order.Customer;
                        o.Remark = order.Remark;

                        o.Items.Clear();
                        foreach (OrderLine orderLine in order.Items)
                            o.Items.Add(orderLine);
                    }
                }
                JsonFileOrderService.SaveJsonOrders(_orders);
            }
        }

        public Order DeleteOrder(int? id)
        {
            Order orderToBeDeleted = null;
            foreach (Order order in _orders)
            {
                if (order.Id == id)
                {
                    orderToBeDeleted = order;
                    break;
                }
            }

            if (orderToBeDeleted != null)
            {
                _orders.Remove(orderToBeDeleted);
                JsonFileOrderService.SaveJsonOrders(_orders);
            }

            return orderToBeDeleted;
        }

        public List<Order> GetOrders() { return _orders; }

        public IEnumerable<Order> CustomerNameSearch(string str)
        {
            List<Order> list = new List<Order>();
            foreach (Order order in _orders)
            {
                if (string.IsNullOrEmpty(str) || order.Customer?.Name?.ToLower().Contains(str.ToLower()) == true)
                {
                    list.Add(order);
                }
            }

            return list;
        }
    }
}
