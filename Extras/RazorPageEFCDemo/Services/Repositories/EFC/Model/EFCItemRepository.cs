using RazorPageEFCDemo.Models;
using RazorPageEFCDemo.Services.Repositories.EFC.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Services.Repositories.EFC.Model
{
    public class EFCItemRepository : EFCRepositoryBase<Item>, IItemRepository
    {
        public EFCItemRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
