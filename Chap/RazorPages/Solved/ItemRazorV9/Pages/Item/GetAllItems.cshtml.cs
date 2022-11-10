using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;

namespace ItemRazorV1.Pages.Item
{
    public class GetAllItemsModel : GetAllPageModelBase<Models.Item, IItemRepository>
    {
        [BindProperty] 
        public string SearchString { get; set; }

        [BindProperty]
        public int MinPrice { get; set; }

        [BindProperty]
        public int MaxPrice { get; set; }

        public GetAllItemsModel(IItemRepository repository) : base(repository)
        {
        }

        public IActionResult OnPostNameSearch()
        {
            Data = _repository.Search(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostPriceFilter()
        {
            Data = _repository.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
