using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class CreateItemModel : CreatePageModel<Models.Item>
    {
        public CreateItemModel(IItemRepository repository)
            : base(repository, "GetAllItems")
        {
        }
    }
}
