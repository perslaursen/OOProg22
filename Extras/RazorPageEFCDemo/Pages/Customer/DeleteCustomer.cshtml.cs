using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Customer
{
    public class DeleteCustomerModel : DeletePageModel<Models.Customer>
    {
        public DeleteCustomerModel(ICustomerRepository repository)
            : base(repository, "GetAllCustomers")
        {
        }
    }
}
