
/// <summary>
/// Interface for a (very simple) statistics service
/// </summary>
/// <typeparam name="TStat">Type of statistics which can be retrieved.</typeparam>
public interface IStatisticsService<TStat>
{
	/// <summary>
	/// Retrieve statistics of type TStat.
	/// </summary>
	TStat GetStats();
}
