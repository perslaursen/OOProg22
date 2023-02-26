using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Customer
{
    public class EditCustomerModel : EditPageModel<Models.Customer>
    {
        public EditCustomerModel(ICustomerRepository repository)
            : base(repository, "GetAllCustomers")
        {
        }
    }
}
