using ItemRazorV1.Base;
using ItemRazorV1.Service.Repositories.Model;

namespace ItemRazorV1.Pages.Item
{
    public class DeleteItemModel : DeletePageModelBase<Models.Item, IItemRepository>
    {
        public DeleteItemModel(IItemRepository repository) 
            : base(repository, "GetAllItems")
        {
        }
    }
}
