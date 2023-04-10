
using Microsoft.EntityFrameworkCore;

public class EFCoreDataServiceAppBase<T> : EFCoreDataServiceBase<T> where T : class, IHasId
{
    /// <summary>
    /// Returns a new instance of the application-specific DbContext class EFCDrinkDBContext.
    /// </summary>
    protected override DbContext CreateDbContext()
    {
        return new EFCDrinkDBContext();
    }
}
