
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Base class for "Edit" page model classes.
/// </summary>
/// <typeparam name="T">Type of entity being edited</typeparam>
public class EditPageModel<T> : PageModelExistingData<T>
    where T : class, IHasId, IUpdateFromOther<T>, new()
{
    public EditPageModel(IDataService<T> dataService, string onPostRedirectPage = DefaultRedirectPage)
        : base(dataService, onPostRedirectPage)
    {
    }

    public virtual IActionResult OnPost()
    {
        // Validate data entered by user
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Submit data to data service
        _dataService.Update(Data.Id, Data);

        return RedirectToPage(_onPostRedirectPage);
    }
}
