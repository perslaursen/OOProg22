using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable // Shut up about null issues...

namespace WebShopV0.Pages.Products
{
    public class CreateModel : PageModel
    {
        private IProductDataService _productDataService;

        [BindProperty]
        public Product Data { get; set; }

        public CreateModel(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        public IActionResult OnPost()
        {
            // Validate data entered by user
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Submit data to data service
            _productDataService.Create(Data);

            return RedirectToPage("All");
        }
    }
}
