
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShopRP.Pages.Orders
{
    public class CreateModel : CreatePageModel<Order>
    {
        public CreateModel(
            IOrderDataService dataService, 
            IProductDataService productDataService, 
            ICustomerDataService customerDataService)
            : base(dataService)
        {
            CustomerList = new SelectList(customerDataService.GetAll(), nameof(Customer.Id), nameof(Customer.Name));
            ProductList = new SelectList(productDataService.GetAll(), nameof(Product.Id), nameof(Product.Name));
        }

        public SelectList CustomerList { get; set; }
        public SelectList ProductList { get; set; }
    }
}
