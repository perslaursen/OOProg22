
/// <summary>
/// A Purse can contain coins of various types, 
/// and various amounts of each type.
/// </summary>
public class Purse
{
    /// <summary>
    /// Return the total value (in kr.) of the Purse content.
    /// </summary>
    public int ValueInKr
    {
        get 
        {
            int total = 0;

            // TODO

            return total; 
        } 
    }

    /// <summary>
    /// Adds coins to the Purse.
    /// </summary>
    public void AddCoins(CoinType coinType, int noOfCoins)
    {
        // TODO
    }

    /// <summary>
    /// Returns the number of coinType coins currently in the purse.
    /// </summary>
    public int GetNoOfCoins(CoinType coinType)
    {
        return 0; // TODO
    }

    /// <summary>
    /// Helper method. Use as-is.
    /// </summary>
    private int ValueOfCoinType(CoinType coinType)
    {
        return Convert.ToInt32(coinType);
    }
}
