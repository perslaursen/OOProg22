
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable // Shut up about null issues...

namespace WebShopV0.Pages.Products
{
    // Page knows this class by the @model directive
    public class AllModel : PageModel 
    {
        // Instance field will reference a Service
        private IProductDataService _productDataService;

        // Property makes data available for Page
        public List<Product> Data { get; private set; }

        // Reference to Service established via Dependency Injection
        public AllModel(IProductDataService productDataService) 
        {
            _productDataService = productDataService;
        }

        // Called when a page needs to be generated.
        // NOW we initialize our data properties by calling the service
        public void OnGet()
        {
            Data = _productDataService.GetAll();
        }
    }
}
