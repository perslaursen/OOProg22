using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;

namespace ItemRazorV1.Pages.Order
{
    public class GetAllOrdersModel : GetAllPageModelBase<Models.Order, IOrderRepository>
    {
        public GetAllOrdersModel(IOrderRepository repo) : base(repo) 
        {
            CustomerSearchString = "";
        }

        [BindProperty]
        public string CustomerSearchString { get; set; }

        public IActionResult OnPostCustomerNameSearch()
        {
            Data = _repository.Search(CustomerSearchString).ToList();
            return Page();
        }
    }
}
