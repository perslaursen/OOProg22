using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageEFCDemo.Services.Repositories.General.Model;

namespace RazorPageEFCDemo.Pages.Order
{
    public class IndexModel : PageModel
    {
        private IOrderRepository _repository;

        public IndexModel(IOrderRepository repository)
        {
            _repository = repository;
        }

        public IList<Models.Order> Data { get; set; } = default!;

        public void OnGet()
        {
            Data = _repository.GetAll().ToList();
        }
    }

    //public class IndexModel : PageModel
    //{
    //    private readonly EFCDemoContext _context;

    //    public IndexModel(EFCDemoContext context)
    //    {
    //        _context = context;
    //    }

    //    public IList<Models.Order> Order { get;set; } = default!;

    //    public async Task OnGetAsync()
    //    {
    //        if (_context.Orders != null)
    //        {
    //            Order = await AddIncludes(_context).ToListAsync();
    //        }
    //    }

    //    private IQueryable<Models.Order> AddIncludes(EFCDemoContext context)
    //    {
    //        return context.Orders.Include(o => o.Customer).Include(o => o.Item);
    //    }
    //}
}
