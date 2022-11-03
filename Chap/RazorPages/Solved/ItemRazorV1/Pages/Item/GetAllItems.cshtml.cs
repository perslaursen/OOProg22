using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItemRazorV1.Pages.Item
{
    public class GetAllItemsModel : PageModel
    {
        public List<Models.Item> Items { get; private set; } = new List<Models.Item> 
        {
            new Models.Item(1, "PC", 5999),
            new Models.Item(2, "Monitor", 1999),
            new Models.Item(3, "Keyboard", 999)
        };

        public void OnGet()
        {
        }
    }
}
