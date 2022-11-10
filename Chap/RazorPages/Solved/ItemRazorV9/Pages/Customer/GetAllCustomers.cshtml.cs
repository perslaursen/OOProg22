using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;
using Microsoft.AspNetCore.Mvc;

namespace ItemRazorV1.Pages.Customer
{
    public class GetAllCustomersModel : GetAllPageModelBase<Models.Customer, ICustomerRepository>
    {
        [BindProperty]
        public string SearchString { get; set; }

        public GetAllCustomersModel(ICustomerRepository repository) : base(repository)
        {
            SearchString = "";
        }

        public IActionResult OnPostNameSearch()
        {
            Data = _repository.Search(SearchString).ToList();
            return Page();
        }
    }
}
