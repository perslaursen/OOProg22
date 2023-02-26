using RazorPageEFCDemo.Pages.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Item
{
    public class GetAllItemsModel : GetAllPageModel<Models.Item>
    {
        public GetAllItemsModel(IItemRepository repository) : base(repository)
        {
        }
    }
}
