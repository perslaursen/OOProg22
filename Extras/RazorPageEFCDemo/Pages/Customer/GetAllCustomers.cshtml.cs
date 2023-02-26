using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Customer
{
    public class GetAllCustomersModel : GetAllPageModel<Models.Customer>
    {
        public GetAllCustomersModel(ICustomerRepository repository) : base(repository)
        {
        }
    }
}
