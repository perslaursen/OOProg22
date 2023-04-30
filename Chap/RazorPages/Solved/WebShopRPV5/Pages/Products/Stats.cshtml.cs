
namespace WebShopRP.Pages.Products
{
    public class StatsModel : StatsPageModel<TotalProductStatistics>
    {
        public StatsModel(IProductStatisticsService productStatisticsService) 
            : base(productStatisticsService)
        {
        }
    }
}
