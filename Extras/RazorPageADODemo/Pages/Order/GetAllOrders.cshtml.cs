using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Order
{
    public class GetAllOrdersModel : GetAllPageModel<Models.Order>
    {
        public GetAllOrdersModel(IOrderRepository repository) : base(repository)
        {
        }
    }
}
