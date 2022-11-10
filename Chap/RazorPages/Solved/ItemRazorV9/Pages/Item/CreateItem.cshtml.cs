using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;

namespace ItemRazorV1.Pages.Item
{
    public class CreateItemModel : CreatePageModelBase<Models.Item, IItemRepository>
    {
        public CreateItemModel(IItemRepository repository) 
            : base(repository, "GetAllItems")
        {
        }
    }
}
