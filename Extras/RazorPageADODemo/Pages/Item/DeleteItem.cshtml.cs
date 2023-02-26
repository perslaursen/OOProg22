using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Item
{
    public class DeleteItemModel : DeletePageModel<Models.Item>
    {
        public DeleteItemModel(IItemRepository repository)
            : base(repository, "GetAllItems")
        {
        }
    }
}
