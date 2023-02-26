using Microsoft.EntityFrameworkCore;
using RazorPageEFCDemo.Data;
using RazorPageEFCDemo.Models;
using RazorPageEFCDemo.Services.Repositories.EFC.Base;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Services.Repositories.EFC.Model
{
    public class EFCOrderRepository : EFCRepositoryBase<Order>, IOrderRepository
    {
        public EFCOrderRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override IQueryable<Order> SetWithIncludes(EFCDemoContext context)
        {
            return context.Set<Order>()
                .Include(o => o.Customer)
                .AsNoTracking()
                .Include(o => o.Item)
                .AsNoTracking();
        }
    }
}
