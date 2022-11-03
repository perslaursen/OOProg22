using ItemRazorV1.Models;

namespace ItemRazorV1.Service
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        Order GetOrder(int id);
        Order DeleteOrder(int? id);
        IEnumerable<Order> CustomerNameSearch(string str);
    }
}
