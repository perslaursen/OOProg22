
namespace WebShopRP.Pages.Products
{
    public class ViewModel : ViewPageModel<Product>
    {
        public ViewModel(IProductDataService dataService) 
            : base(dataService)
        {
        }
    }
}
