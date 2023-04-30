
/// <summary>
/// Statistics service for Customers.
/// </summary>
public class CustomerStatisticsService : StatisticsServiceBase<Customer, CustomerStatistics, TotalCustomerStatistics> , ICustomerStatisticsService
{
    public CustomerStatisticsService(ICustomerDataService customerDataService) : base(customerDataService)
    {
    }

    protected override CustomerStatistics CreateStatistics(Customer t) => new CustomerStatistics(t);
    protected override TotalCustomerStatistics CreateTotalStatistics() => new TotalCustomerStatistics();
}
