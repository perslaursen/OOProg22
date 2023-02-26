using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Customer
{
    public class CreateCustomerModel : CreatePageModel<Models.Customer>
    {
        public CreateCustomerModel(ICustomerRepository repository)
            : base(repository, "GetAllCustomers")
        {
        }
    }
}
