
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
#nullable disable

/// <summary>
/// General base class for page model classes.
/// A page model will "manipulate" (i.e. access and/or create) a data entity of type TData.
/// </summary>
/// <typeparam name="TData">Type of data being manipulated by the page</typeparam>
public class PageModelAppBase<TData> : PageModel 
    where TData : class, IHasId, IUpdateFromOther<TData>, new()
{
    public const string DefaultRedirectPage = "All";
    public const string DefaultErrorPage = "/Error";

    /// <summary>
    /// Data service reference corresponding to the data entity type
    /// </summary>
    protected IDataService<TData> _dataService; 


    /// <summary>
    /// Page to redirect to, after OnPost logic is done.
    /// </summary>
    protected string _onPostRedirectPage;

    /// <summary>
    /// Data entity to be manipulated by the page model.
    /// </summary>
    [BindProperty]
    public TData Data { get; set; } = new TData();

    public PageModelAppBase(IDataService<TData> dataService, string onPostRedirectPage = DefaultRedirectPage)
    {
        _dataService = dataService;
        _onPostRedirectPage = onPostRedirectPage;
    }
}
