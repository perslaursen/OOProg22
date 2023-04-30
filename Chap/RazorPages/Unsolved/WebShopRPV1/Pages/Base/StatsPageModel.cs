
using Microsoft.AspNetCore.Mvc.RazorPages;
#nullable disable

/// <summary>
/// Base class for "Statistics" page model classes.
/// </summary>
/// <typeparam name="T">Type of statistics being shown</typeparam>
public class StatsPageModel<T> : PageModel
{
	private IStatisticsService<T> _statisticsService;

	public T Statistics { get; private set; }

	public StatsPageModel(IStatisticsService<T> statisticsService)
	{
		_statisticsService = statisticsService;
	}

	public void OnGet()
	{
		Statistics = _statisticsService.GetStats();
	}
}
