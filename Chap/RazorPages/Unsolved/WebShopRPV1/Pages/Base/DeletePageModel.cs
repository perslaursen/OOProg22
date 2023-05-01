
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Base class for "Delete" page model classes.
/// </summary>
/// <typeparam name="T">Type of entity being deleted</typeparam>
public class DeletePageModel<T> : PageModelExistingData<T>
    where T : class, IHasId, IUpdateFromOther<T>, new()
{
    public DeletePageModel(IDataService<T> dataService, string onPostRedirectPage = DefaultRedirectPage)
        : base(dataService, onPostRedirectPage)
    {
    }

    public virtual IActionResult OnPost()
    {
        _dataService.Delete(Data.Id);

        return RedirectToPage(_onPostRedirectPage);
    }
}
