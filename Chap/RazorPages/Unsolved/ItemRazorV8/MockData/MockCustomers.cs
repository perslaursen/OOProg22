using ItemRazorV1.Models;

namespace ItemRazorV1.MockData
{
    public class MockCustomers
    {
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer(1, "Anders", "and@mail.dk", "Stien 12"),
            new Customer(2, "Bente", "ben@mail.dk", "Ved Skoven 8"),
            new Customer(3, "Carina", "car@mail.dk", "Skolevej 87")
        };

        public static List<Customer> GetMockCustomers() { return _customers; }
    }
}
