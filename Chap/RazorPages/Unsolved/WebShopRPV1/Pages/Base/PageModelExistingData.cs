
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Base class for all page model classes which manipulate existing data.
/// This is typically Edit, Delete and View pages.
/// </summary>
/// <typeparam name="T">Type of data being manipulated by the page</typeparam>
public class PageModelExistingData<T> : PageModelAppBase<T>
    where T : class, IHasId, IUpdateFromOther<T>, new()
{
    public PageModelExistingData(IDataService<T> dataService, string onPostRedirectPage = DefaultRedirectPage) 
        : base(dataService, onPostRedirectPage)
    {
    }

    /// <summary>
    /// Default implementation of parameterized OnGet
    /// </summary>
    /// <param name="id">Id of data to get</param>
    public virtual IActionResult OnGet(int id)
    {
        T? data = _dataService.Read(id);

        if (data == null)
            return RedirectToPage(DefaultErrorPage);

        Data = data;
        return Page();
    }
}
