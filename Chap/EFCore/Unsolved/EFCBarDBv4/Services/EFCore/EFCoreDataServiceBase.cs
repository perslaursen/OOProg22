
/// <summary>
/// Base class implementation of the IDataService<T> interface 
/// by means of Enitity Framework Core.
/// </summary>
/// <typeparam name="T">Type of objects managed by service</typeparam>
public class EFCoreDataServiceBase<T> : IDataService<T> where T : class, IHasId
{
    public List<T> GetAll()
    {
        using EFCDrinkDBContext context = new EFCDrinkDBContext();

        return GetAllWithIncludes(context).ToList();
    }

    public virtual int Create(T t)
    {
        using EFCDrinkDBContext context = new EFCDrinkDBContext();

        context.Set<T>().Add(t);
        context.SaveChanges();

        return t.Id;
    }

    public T? Read(int id)
    {
        using EFCDrinkDBContext context = new EFCDrinkDBContext();

        return GetAllWithIncludes(context).FirstOrDefault(t => t.Id == id);
    }

    public bool Delete(int id)
    {
        using EFCDrinkDBContext context = new EFCDrinkDBContext();

        T? tEx = GetAllWithIncludes(context).FirstOrDefault(t => t.Id == id);
        if (tEx == null)
            return false;

        context.Set<T>().Remove(tEx);
        return (context.SaveChanges() > 0);
    }

    protected virtual IQueryable<T> GetAllWithIncludes(EFCDrinkDBContext context)
    {
        return context.Set<T>();
    }
}

