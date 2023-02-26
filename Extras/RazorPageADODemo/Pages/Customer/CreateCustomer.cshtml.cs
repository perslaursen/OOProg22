using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Customer
{
    public class CreateCustomerModel : CreatePageModel<Models.Customer>
    {
        public CreateCustomerModel(ICustomerRepository repository)
            : base(repository, "GetAllCustomers")
        {
        }
    }
}
