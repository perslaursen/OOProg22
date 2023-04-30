
namespace WebShopRP.Pages.Customers
{
    public class DeleteModel : DeletePageModel<Customer>
    {
        public DeleteModel(ICustomerDataService dataService)
            : base(dataService)
        {
        }
    }
}
