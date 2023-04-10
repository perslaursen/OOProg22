
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Base class implementation of the IDataService<T> interface 
/// by means of Enitity Framework Core.
/// </summary>
/// <typeparam name="T">Type of objects managed by service</typeparam>
public abstract class EFCoreDataServiceBase<T> : IDataService<T> where T : class, IHasId
{
    #region IDataService implementation
    
    public List<T> GetAll()
    {
        using DbContext context = CreateDbContext();

        return GetAllWithIncludes(context).ToList();
    }

    public virtual int Create(T t)
    {
        using DbContext context = CreateDbContext();

        context.Set<T>().Add(t);
        context.SaveChanges();

        return t.Id;
    }

    public T? Read(int id)
    {
        using DbContext context = CreateDbContext();

        return GetAllWithIncludes(context).FirstOrDefault(t => t.Id == id);
    }

    public bool Delete(int id)
    {
        using DbContext context = CreateDbContext();

        T? tEx = GetAllWithIncludes(context).FirstOrDefault(t => t.Id == id);
        if (tEx == null)
            return false;

        context.Set<T>().Remove(tEx);
        return (context.SaveChanges() > 0);
    }
    
    #endregion


    // This method should return all objects of type T with deep-resolve of all object references.
    // (deep-resolve: all object references resolved, also on child objects)
    // Derived classes can override if needed.
    protected virtual IQueryable<T> GetAllWithIncludes(DbContext context)
    {
        return context.Set<T>();
    }

    /// <summary>
    /// Factory-like method for returning application-specific DbContext class.
    /// </summary>
    /// <returns></returns>
    protected abstract DbContext CreateDbContext();
}

