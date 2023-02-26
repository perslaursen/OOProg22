using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Item
{
    public class GetAllItemsModel : GetAllPageModel<Models.Item>
    {
        public GetAllItemsModel(IItemRepository repository) : base(repository)
        {
        }
    }
}
