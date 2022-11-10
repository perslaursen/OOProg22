using ItemRazorV1.Models;
using ItemRazorV1.Service.Repositories.Base;

namespace ItemRazorV1.Service.Repositories.Model
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IWebHostEnvironment WebHostEnvironment)
            : base(new JsonFileRepositoryBase<Order>(WebHostEnvironment, "Orders.json"))
        {
        }

        protected override bool SearchMatch(Order t, string str)
        {
            return string.IsNullOrEmpty(str) || t.Customer?.Name?.ToLower().Contains(str.ToLower()) == true;
        }
    }
}
