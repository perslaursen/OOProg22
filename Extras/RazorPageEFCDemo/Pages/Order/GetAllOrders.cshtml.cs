using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Order
{
    public class GetAllOrdersModel : GetAllPageModel<Models.Order>
    {
        public GetAllOrdersModel(IOrderRepository repository) : base(repository)
        {
        }
    }
}
