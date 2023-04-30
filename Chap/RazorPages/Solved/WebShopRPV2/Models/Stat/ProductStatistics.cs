
/// <summary>
/// Statistics for one specific Product.
/// </summary>
public class ProductStatistics : StatisticsBase<Product>
{
    public ProductStatistics(Product product) : base(product) { }
}

/// <summary>
/// Statistics for all Products.
/// </summary>
public class TotalProductStatistics : TotalStatisticsBase<Product, ProductStatistics>
{
}
