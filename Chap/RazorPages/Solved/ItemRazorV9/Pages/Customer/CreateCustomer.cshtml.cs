using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;

namespace ItemRazorV1.Pages.Customer
{
    public class CreateCustomerModel : CreatePageModelBase<Models.Customer, ICustomerRepository>
    {
        public CreateCustomerModel(ICustomerRepository repository) 
            : base(repository, "GetAllCustomers")
        {
        }
    }
}
