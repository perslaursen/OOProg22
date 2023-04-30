
namespace WebShopRP.Pages.Customers
{
    public class ViewModel : ViewPageModel<Customer>
    {
        public ViewModel(ICustomerDataService dataService) 
            : base(dataService)
        {
        }
    }
}
