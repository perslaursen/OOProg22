
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Base class for "Create" page model classes.
/// </summary>
/// <typeparam name="T">Type of entity being created</typeparam>
public class CreatePageModel<T> : PageModelAppBase<T>
    where T : class, IHasId, IUpdateFromOther<T>, new()
{
    public CreatePageModel(IDataService<T> dataService, string onPostRedirectPage = DefaultRedirectPage)
        : base(dataService, onPostRedirectPage)
    {
    }

    public virtual IActionResult OnGet()
    {
        return Page();
    }

    public virtual IActionResult OnPost()
    {
        // Validate data entered by user
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Submit data to data service
        _dataService.Create(Data);

        return RedirectToPage(_onPostRedirectPage);
    }
}
