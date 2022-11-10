using ItemRazorV1.Models;
using ItemRazorV1.Service.Repositories.Base;

namespace ItemRazorV1.Service.Repositories.Model
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(IWebHostEnvironment WebHostEnvironment) 
            : base(new JsonFileRepositoryBase<Item>(WebHostEnvironment, "Items.json"))
        {
        }

        public IEnumerable<Item> PriceFilter(int maxPrice, int minPrice = 0)
        {
            return GetAll().Where(t => (minPrice == 0 && t.Price <= maxPrice) || 
                                       (maxPrice == 0 && t.Price >= minPrice) || 
                                       (t.Price >= minPrice && t.Price <= maxPrice)
                                  );
        }

        protected override bool SearchMatch(Item t, string str)
        {
            return  string.IsNullOrEmpty(str) || t?.Name?.ToLower().Contains(str.ToLower()) == true;
        }
    }
}
