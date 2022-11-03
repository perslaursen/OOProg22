using ItemRazorV1.MockData;
using ItemRazorV1.Models;

namespace ItemRazorV1.Service
{
    public class ItemService : IItemService
    {
        private List<Item> _items;

        private JsonFileItemService JsonFileItemService { get; set; }

        public ItemService(JsonFileItemService jsonFileItemService)
        {
            JsonFileItemService = jsonFileItemService;
            // _items = MockItems.GetMockItems();
            _items = JsonFileItemService.GetJsonItems().ToList();
        }

        public ItemService()
        {
            _items = MockItems.GetMockItems();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            JsonFileItemService.SaveJsonItems(_items);
        }

        public Item GetItem(int id)
        {
            foreach (Item item in _items)
            {
                if (item.Id == id)
                    return item;
            }

            return null;
        }

        public void UpdateItem(Item item)
        {
            if (item != null)
            {
                foreach (Item i in _items)
                {
                    if (i.Id == item.Id)
                    {
                        i.Name = item.Name;
                        i.Price = item.Price;
                    }
                }
                JsonFileItemService.SaveJsonItems(_items);
            }
        }

        public Item DeleteItem(int? itemId)
        {
            Item itemToBeDeleted = null;
            foreach (Item item in _items)
            {
                if (item.Id == itemId)
                {
                    itemToBeDeleted = item;
                    break;
                }
            }

            if (itemToBeDeleted != null)
            {
                _items.Remove(itemToBeDeleted);
                JsonFileItemService.SaveJsonItems(_items);
            }

            return itemToBeDeleted;
        }

        public List<Item> GetItems() { return _items; }

        public IEnumerable<Item> NameSearch(string str)
        {
            List<Item> nameSearch = new List<Item>();
            foreach (Item item in _items)
            {
                if (string.IsNullOrEmpty(str) || item.Name.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(item);
                }
            }

            return nameSearch;
        }

        public IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Item> filterList = new List<Item>();
            foreach (Item item in _items)
            {
                if ((minPrice == 0 && item.Price <= maxPrice) || (maxPrice == 0 && item.Price >= minPrice) || (item.Price >= minPrice && item.Price <= maxPrice))
                {
                    filterList.Add(item);
                }
            }

            return filterList;
        }
    }
}
