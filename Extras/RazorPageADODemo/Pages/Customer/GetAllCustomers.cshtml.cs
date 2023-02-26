using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Customer
{
    public class GetAllCustomersModel : GetAllPageModel<Models.Customer>
    {
        public GetAllCustomersModel(ICustomerRepository repository) : base(repository)
        {
        }
    }
}
