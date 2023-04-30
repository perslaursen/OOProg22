using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable // Shut up about null issues...

namespace WebShopV0.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private IProductDataService _productDataService;

        [BindProperty]
        public Product Data { get; set; }

        public DeleteModel(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        public virtual IActionResult OnGet(int id)
        {
            Product data = _productDataService.Read(id);

            if (data == null)
                return RedirectToPage("Error");

            Data = data;
            return Page();
        }

        public virtual IActionResult OnPost()
        {
            _productDataService.Delete(Data.Id);

            return RedirectToPage("All");
        }
    }
}
