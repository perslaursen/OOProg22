
namespace WebShopRP.Pages.Products
{
    public class DeleteModel : DeletePageModel<Product>
    {
        public DeleteModel(IProductDataService dataService)
            : base(dataService)
        {
        }
    }
}
