
/// <summary>
/// This class simulates a calculation of a value depending on an x and y value. 
/// The calculation is simulated to take some time (see Constants).
/// However, the simulator may optionally use a cache to speed
/// up the caluclation.
/// </summary>
public class Simulator
{
    #region Instance fields
    private Random _generator;
    private Cache? _cache;

    private int _xDimension;
    private int _yDimension;
    #endregion

    #region Constructor
    /// <summary>
    /// Only create the cache if specified
    /// </summary>
    public Simulator(int xDimension, int yDimension, bool useCache)
    {
        _generator = new Random();
        _xDimension = xDimension;
        _yDimension = yDimension;
        _cache = (useCache ? new Cache(xDimension, yDimension) : null);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Simulate a calculation, possibly using a cached value.
    /// </summary>
    public int? Calculate(int x, int y)
    {
        int? result = null;

        if (x < _xDimension && x >= 0 && y < _yDimension && y >= 0)
        {
            if (_cache != null)
            {
                result = _cache.Lookup(x, y);
            }

            if (result == null)
            {
                result = DoCalculation(x, y);

                if (_cache != null)
                {
                    _cache.Insert(x, y, result.Value);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Simulate an actual calculation
    /// </summary>
    private int DoCalculation(int x, int y)
    {
        Pause(Constants.SimulationTimeInMilliSecs);
        return _generator.Next(Constants.CalculationMinValue, Constants.CalculationMaxValue);
    }

    /// <summary>
    /// Pause for the specified number of milliseconds
    /// </summary>
    private void Pause(int mSecs)
    {
        Thread.Sleep(mSecs);
    }
    #endregion
}
