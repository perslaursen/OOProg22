using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class DeleteItemModel : DeletePageModel<Models.Item>
    {
        public DeleteItemModel(IItemRepository repository)
            : base(repository, "GetAllItems")
        {
        }
    }
}
