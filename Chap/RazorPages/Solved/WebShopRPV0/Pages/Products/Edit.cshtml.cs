using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable // Shut up about null issues...

namespace WebShopV0.Pages.Products
{
    public class EditModel : PageModel
    {
        private IProductDataService _productDataService;

        [BindProperty]
        public Product Data { get; set; }

        public EditModel(IProductDataService productDataService)
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
            // Validate data entered by user
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Submit data to data service
            _productDataService.Update(Data.Id, Data);

            return RedirectToPage("All");
        }
    }
}
