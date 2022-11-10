using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;

namespace ItemRazorV1.Pages.Order
{
    public class DeleteOrderModel : DeletePageModelBase<Models.Order, IOrderRepository>
    {
        public DeleteOrderModel(IOrderRepository repository) 
            : base(repository, "GetAllOrders")
        {
        }
    }
}
