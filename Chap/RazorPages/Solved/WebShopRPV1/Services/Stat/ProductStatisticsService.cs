
/// <summary>
/// Statistics service for Products.
/// </summary>
public class ProductStatisticsService : StatisticsServiceBase<Product, ProductStatistics, TotalProductStatistics> , IProductStatisticsService
{
    public ProductStatisticsService(IProductDataService productDataService) : base(productDataService)
    {
    }

    protected override ProductStatistics CreateStatistics(Product t) => new ProductStatistics(t);
    protected override TotalProductStatistics CreateTotalStatistics() => new TotalProductStatistics();
}
