
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Base class for an Entity Framework Core-based data service implementation.
/// </summary>
/// <typeparam name="TData">Type of entities being managed</typeparam>
public abstract class EFCDataServiceBase<TData> : IDataService<TData> where TData : class, IHasId, IUpdateFromOther<TData>
{
    public List<TData> GetAll()
    {
        using DbContext context = CreateDBContext();

        return GetAllWithIncludes(context).ToList();
    }

    public virtual int Create(TData t)
    {
        using DbContext context = CreateDBContext();

        context.Set<TData>().Add(t);
        context.SaveChanges();

        return t.Id;
    }

    public virtual TData? Read(int id)
    {
        using DbContext context = CreateDBContext();

        return GetAllWithIncludes(context).FirstOrDefault(e => e.Id == id);
    }

    public virtual bool Update(int id, TData t)
    {
        using DbContext context = CreateDBContext();

        TData? tExisting = context.Set<TData>().Find(id);
        if (tExisting == null)
            return false;

        tExisting.Update(t);
        return (context.SaveChanges() > 0);
    }

    public virtual bool Delete(int id)
    {
        using DbContext context = CreateDBContext();

        TData? tExisting = context.Set<TData>().Find(id);
        if (tExisting == null)
            return false;

        context.Set<TData>().Remove(tExisting);
        return (context.SaveChanges() > 0);
    }

    /// <summary>
    /// Override to specify which specific DbContext to create 
    /// when a context object is needed.
    /// </summary>
    protected abstract DbContext CreateDBContext();

    /// <summary>
    /// Override to specify which navigation properties to include
    /// when retrieving the data collection.
    /// </summary>
    protected virtual IQueryable<TData> GetAllWithIncludes(DbContext context)
    {
        return context.Set<TData>();
    }
}
