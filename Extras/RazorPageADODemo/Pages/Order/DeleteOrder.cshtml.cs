using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Order
{
    public class DeleteOrderModel : DeletePageModel<Models.Order>
    {
        public DeleteOrderModel(IOrderRepository repository)
            : base(repository, "GetAllOrders")
        {
        }
    }
}
