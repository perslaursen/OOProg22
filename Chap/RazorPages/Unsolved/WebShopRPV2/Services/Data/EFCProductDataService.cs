
using Microsoft.EntityFrameworkCore;

public class EFCProductDataService : EFCDataServiceAppBase<Product>, IProductDataService
{
	protected override IQueryable<Product> GetAllWithIncludes(DbContext context)
	{
		return context.Set<Product>()
			.Include(c => c.Orders);
	}
}
