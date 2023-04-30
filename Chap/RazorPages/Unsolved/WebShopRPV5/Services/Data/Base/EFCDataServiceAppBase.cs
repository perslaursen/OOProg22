
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Application-specific base class for an Entity Framework Core-based data service implementation.
/// </summary>
/// <typeparam name="TData">Type of entities being managed</typeparam>
public class EFCDataServiceAppBase<T> : EFCDataServiceBase<T> where T : class, IHasId, IUpdateFromOther<T>
{
    /// <summary>
    /// Specifies that a WebShopDBContext object is created 
    /// whenever a context object is needed.
    /// </summary>
    protected override DbContext CreateDBContext() => new WebShopDBContext();
}
