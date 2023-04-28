
namespace WebShopRP.Pages.Products
{
    public class CreateModel : CreatePageModel<Product>
    {
        public CreateModel(IProductDataService dataService)
            : base(dataService)
        {
        }
    }
}
