using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;

namespace ItemRazorV1.Pages.Item
{
    public class EditItemModel : EditPageModelBase<Models.Item, IItemRepository>
    {
        public EditItemModel(IItemRepository repository) 
            : base(repository, "GetAllItems")
        {
        }
    }
}
