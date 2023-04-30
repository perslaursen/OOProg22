
namespace WebShopRP.Pages.Customers
{
    public class StatsModel : StatsPageModel<TotalCustomerStatistics>
    {
        /// <summary>
        /// This property enables display of per-product statistics for each Customer.
        /// </summary>
        public IEnumerable<Product> Products { get; }

        public StatsModel(ICustomerStatisticsService customerStatisticsService, IProductDataService productDataService) 
            : base(customerStatisticsService)
        {
            Products = productDataService.GetAll();
        }
    }
}
