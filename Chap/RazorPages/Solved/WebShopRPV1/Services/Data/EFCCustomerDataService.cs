
using Microsoft.EntityFrameworkCore;

public class EFCCustomerDataService : EFCDataServiceAppBase<Customer>, ICustomerDataService
{
	protected override IQueryable<Customer> GetAllWithIncludes(DbContext context)
	{
		return context.Set<Customer>()
			.Include(c => c.Orders)
				.ThenInclude(o => o.Product);
	}
}
