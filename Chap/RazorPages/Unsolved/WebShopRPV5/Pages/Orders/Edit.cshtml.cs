
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShopRP.Pages.Orders
{
    public class EditModel : EditPageModel<Order>
    {
        public EditModel(IOrderDataService dataService, IProductDataService productDataService, ICustomerDataService customerDataService)
            : base(dataService)
        {
            CustomerList = new SelectList(customerDataService.GetAll(), nameof(Customer.Id), nameof(Customer.Name));
            ProductList = new SelectList(productDataService.GetAll(), nameof(Product.Id), nameof(Product.Name));
        }

        public SelectList CustomerList { get; set; }
        public SelectList ProductList { get; set; }
    }
}
