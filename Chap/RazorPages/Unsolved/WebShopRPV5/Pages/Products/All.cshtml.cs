
namespace WebShopRP.Pages.Products
{
    public class AllModel : GetAllPageModel<Product>
    {
        public AllModel(IProductDataService dataService) 
            : base(dataService)
        {
        }
    }
}
