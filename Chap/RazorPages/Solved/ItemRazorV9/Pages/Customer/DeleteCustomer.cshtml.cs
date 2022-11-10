using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;

namespace ItemRazorV1.Pages.Customer
{
    public class DeleteCustomerModel : DeletePageModelBase<Models.Customer, ICustomerRepository>
    {
        public DeleteCustomerModel(ICustomerRepository repository) 
            : base(repository, "GetAllCustomers")
        {
        }
    }
}
