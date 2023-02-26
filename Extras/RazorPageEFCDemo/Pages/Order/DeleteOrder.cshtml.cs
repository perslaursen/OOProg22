using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Order
{
    public class DeleteOrderModel : DeletePageModel<Models.Order>
    {
        public DeleteOrderModel(IOrderRepository repository)
            : base(repository, "GetAllOrders")
        {
        }
    }
}
