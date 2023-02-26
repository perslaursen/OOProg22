using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Customer
{
    public class DeleteCustomerModel : DeletePageModel<Models.Customer>
    {
        public DeleteCustomerModel(ICustomerRepository repository) 
            : base(repository, "GetAllCustomers")
        {
        }
    }
}
