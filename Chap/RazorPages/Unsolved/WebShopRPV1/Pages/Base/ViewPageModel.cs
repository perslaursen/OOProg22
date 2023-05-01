
/// <summary>
/// Base class for "View" page model classes.
/// </summary>
/// <typeparam name="T">Type of entity being viewed</typeparam>
public class ViewPageModel<T> : PageModelExistingData<T>
    where T : class, IHasId, IUpdateFromOther<T>, new()
{
    public ViewPageModel(IDataService<T> dataService) 
        : base(dataService)
    {
    }
}
