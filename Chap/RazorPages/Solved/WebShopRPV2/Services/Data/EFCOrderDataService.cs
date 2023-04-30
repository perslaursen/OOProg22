
using Microsoft.EntityFrameworkCore;

public class EFCOrderDataService : EFCDataServiceAppBase<Order>, IOrderDataService
{
    protected override IQueryable<Order> GetAllWithIncludes(DbContext context)
    {
        return context.Set<Order>()
            .Include(o => o.Customer)
            .Include(o => o.Product);
    }
}
