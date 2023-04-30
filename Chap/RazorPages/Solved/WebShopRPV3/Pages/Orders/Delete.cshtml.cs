
namespace WebShopRP.Pages.Orders
{
    public class DeleteModel : DeletePageModel<Order>
    {
        public DeleteModel(IOrderDataService dataService)
            : base(dataService)
        {
        }
    }
}
