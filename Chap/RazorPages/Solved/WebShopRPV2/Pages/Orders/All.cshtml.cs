
namespace WebShopRP.Pages.Orders
{
    public class AllModel : GetAllPageModel<Order>
    {
        public AllModel(IOrderDataService dataService) 
            : base(dataService)
        {
        }
    }
}
