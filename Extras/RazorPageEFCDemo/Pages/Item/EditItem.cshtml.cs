using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class EditItemModel : EditPageModel<Models.Item>
    {
        public EditItemModel(IItemRepository repository)
            : base(repository, "GetAllItems")
        {
        }
    }
}
