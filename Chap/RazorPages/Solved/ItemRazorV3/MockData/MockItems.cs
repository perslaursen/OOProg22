using ItemRazorV1.Models;

namespace ItemRazorV1.MockData
{
    public class MockItems
    {
        private static List<Item> _items = new List<Item>() 
        {
            new Item(1, "PC", 5999),
            new Item(2, "Monitor", 1999),
            new Item(3, "Keyboard", 999)
        };

        public static List<Item> GetMockItems() { return _items; }
    }
}
