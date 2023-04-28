
/// <summary>
/// Base class for order-oriented statistics service.
/// </summary>
/// <typeparam name="TData">Type of entity to which individual statistics apply.</typeparam>
/// <typeparam name="TStat">Type of individual statistics for an entity.</typeparam>
/// <typeparam name="TTotalStat">Type of total statistics for a data type.</typeparam>
public abstract class StatisticsServiceBase<TData, TStat, TTotalStat> : IStatisticsService<TTotalStat> 
    where TData : class, IHasId, IHasName, IHasOrders, IUpdateFromOther<TData>
    where TStat : IStatistics<TData>
    where TTotalStat : ITotalStatistics<TData, TStat>

{
    private IDataService<TData> _dataService;

    public StatisticsServiceBase(IDataService<TData> dataService)
    {
        _dataService = dataService;
    }

    public TTotalStat GetStats()
    {
        List<TData> all = _dataService.GetAll();

        TTotalStat totalStats = CreateTotalStatistics();

        all.ForEach(p => totalStats.AddStat(CreateStatistics(p)));

        return totalStats;
    }

    /// <summary>
    /// Override to specify which total statistics object to create 
    /// when such an object is needed.
    /// </summary>
    protected abstract TTotalStat CreateTotalStatistics();

    /// <summary>
    /// Override to specify which individual statistics object to create 
    /// when such an object is needed.
    /// </summary>
    protected abstract TStat CreateStatistics(TData t);
}
