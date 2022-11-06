using ItemRazorV1.Models;

namespace ItemRazorV1.MockData
{
    public class MockOrders
    {
        private static List<Order> _orders;

        static MockOrders()
        {
            Order o1 = new Order(1, new Customer(1, "Anders", "and@mail.dk", "Stien 12"));
            Order o2 = new Order(2, new Customer(3, "Carina", "car@mail.dk", "Skolevej 87"));
            Order o3 = new Order(3, new Customer(1, "Anders", "and@mail.dk", "Stien 12"));

            o1.Items.Add(new OrderLine(new Item(1, "PC", 5999), 1));
            o1.Items.Add(new OrderLine(new Item(2, "Monitor", 1999), 2));

            o2.Items.Add(new OrderLine(new Item(3, "Keyboard", 999), 3));

            o3.Items.Add(new OrderLine(new Item(1, "PC", 5999), 1));
            o3.Items.Add(new OrderLine(new Item(3, "Keyboard", 999), 2));

            o1.Remark = "This is the first order";
            o2.Remark = "This is the second order";
            o3.Remark = "This is the third order";

            _orders = new List<Order>() { o1, o2, o3 };
        }


        public static List<Order> GetMockOrders() { return _orders; }
    }
}
