
namespace WebShopRP.Pages.Customers
{
    public class CreateModel :  CreatePageModel<Customer>
    {
        public CreateModel(ICustomerDataService dataService) 
            : base(dataService)
        {
        }
    }
}
