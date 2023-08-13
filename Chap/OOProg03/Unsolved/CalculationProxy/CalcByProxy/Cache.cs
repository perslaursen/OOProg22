
/// <summary>
/// This class implements a cache for storing calculation results.
/// A Coordinate is mapped to a specific cached value.
/// </summary>
public class Cache
{
    #region Instance fields
    private Dictionary<Coordinate, int> _cacheValues;
    #endregion

    #region Constructor
    public Cache()
    {
        _cacheValues = new Dictionary<Coordinate, int>();
        NoOfCachedValues = 0;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Look up the value corresponding to given coordinate.
    /// If no value is stored for the given coordinate, null is returned.
    /// </summary>
    public int? Lookup(Coordinate c)
    {
        return _cacheValues.ContainsKey(c) ? _cacheValues[c] : null;
    }

    /// <summary>
    /// Store the value calculated for given Coordinate
    /// </summary>
    public void Insert(Coordinate c, int value)
    {
        _cacheValues[c] = value;
        NoOfCachedValues++;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Extra feature to be able to monitor
    /// the current number of cached values
    /// </summary>
    public static int NoOfCachedValues { get; private set; }
    #endregion
}
