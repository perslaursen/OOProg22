
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable

/// <summary>
/// Base class for "All" page model classes.
/// </summary>
/// <typeparam name="T">Type of entities being shown</typeparam>
public class GetAllPageModel<T> : PageModel
    where T : class, IHasId, IUpdateFromOther<T>, new()
{
    private IDataService<T> _dataService;

    /// <summary>
    /// Collection of entities to show
    /// </summary>
    public List<T> Data { get; protected set; }

    public GetAllPageModel(IDataService<T> dataService)
    {
        _dataService = dataService;
    }

    public virtual void OnGet()
    {
        Data = _dataService.GetAll().ToList();
    }
}
