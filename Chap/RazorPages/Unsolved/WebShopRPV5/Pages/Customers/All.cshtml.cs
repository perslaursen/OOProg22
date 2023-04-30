
namespace WebShopRP.Pages.Customers
{
    public class AllModel : GetAllPageModel<Customer>
    {
        public AllModel(ICustomerDataService dataService) 
            : base(dataService)
        {
        }
    }
}