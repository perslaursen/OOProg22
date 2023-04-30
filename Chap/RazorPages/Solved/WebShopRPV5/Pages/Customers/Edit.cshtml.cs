
namespace WebShopRP.Pages.Customers
{
    public class EditModel : EditPageModel<Customer>
    {
        public EditModel(ICustomerDataService dataService) 
            : base(dataService) 
        { 
        }
    }
}
