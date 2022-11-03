using ItemRazorV1.Models;

namespace ItemRazorV1.Service
{
    public interface IItemService
    {
        List<Item> GetItems();
        void AddItem(Item item);
        IEnumerable<Item> NameSearch(string str);
        IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0);
    }
}
