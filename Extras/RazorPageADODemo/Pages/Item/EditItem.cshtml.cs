using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Item
{
    public class EditItemModel : EditPageModel<Models.Item>
    {
        public EditItemModel(IItemRepository repository)
            : base(repository, "GetAllItems")
        {
        }
    }
}
