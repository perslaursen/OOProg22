
/// <summary>
/// Statistics for one specific Customer.
/// </summary>
public class CustomerStatistics : StatisticsBase<Customer>
{
    public CustomerStatistics(Customer customer) : base(customer) {}

    /// <summary>
    /// Returns the amount of products ordered which match the given product id.
    /// </summary>
    public int AmountCountByProductId(int productId) => Orders.Where(o => o.ProductId == productId).Select(o => o.Amount).Sum();
}

/// <summary>
/// Statistics for all Customers.
/// </summary>
public class TotalCustomerStatistics : TotalStatisticsBase<Customer, CustomerStatistics>
{
    /// <summary>
    /// Returns the amount of products ordered which match the given product id.
    /// </summary>
    public int AmountCountByProductId(int productId) => Stats.Select(kvp => kvp.Value.AmountCountByProductId(productId)).Sum();
}
