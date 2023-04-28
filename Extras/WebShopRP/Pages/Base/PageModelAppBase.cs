
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
#nullable disable

/// <summary>
/// General base class for page model classes.
/// A page model will "manipulate" (i.e. access and/or create) a data entity of type TStat.
/// </summary>
/// <typeparam name="T">Type of data being manipulated by the page</typeparam>
public class PageModelAppBase<T> : PageModel where T : class, IHasId, IUpdateFromOther<T>
{
    public const string DefaultRedirectPage = "All";
    public const string DefaultErrorPage = "/Error";

    /// <summary>
    /// Data service reference corresponding to the data entity type
    /// </summary>
    protected IDataService<T> _dataService; 


    /// <summary>
    /// Page to redirect to, after OnPost logic is done.
    /// </summary>
    protected string _onPostRedirectPage;

    /// <summary>
    /// Data entity to be manipulated by the page model.
    /// </summary>
    [BindProperty]
    public T Data { get; set; }

    public PageModelAppBase(IDataService<T> dataService, string onPostRedirectPage = DefaultRedirectPage)
    {
        _dataService = dataService;
        _onPostRedirectPage = onPostRedirectPage;
    }
}
