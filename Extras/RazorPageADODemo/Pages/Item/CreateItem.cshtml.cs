using RazorPageADODemo.Pages.Base;
using RazorPageADODemo.Services.Repositories.General.Model;

namespace RazorPageADODemo.Pages.Item
{
    public class CreateItemModel : CreatePageModel<Models.Item>
    {
        public CreateItemModel(IItemRepository repository) 
            : base(repository, "GetAllItems")
        {
        }
    }
}
