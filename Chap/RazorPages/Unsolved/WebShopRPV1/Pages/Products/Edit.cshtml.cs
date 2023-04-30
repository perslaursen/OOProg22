
namespace WebShopRP.Pages.Products
{
    public class EditModel : EditPageModel<Product>
    {
        public EditModel(IProductDataService dataService)
            : base(dataService)
        {
        }
    }
}
