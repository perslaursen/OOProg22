
namespace WebShopRP.Pages.Orders
{
    public class ViewModel : ViewPageModel<Order>
    {
        public ViewModel(IOrderDataService dataService)
            : base(dataService)
        {
        }
    }
}
