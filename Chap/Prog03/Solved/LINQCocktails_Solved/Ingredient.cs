
/// <summary>
/// This class represents a cocktail ingredient,
/// limited to liquid ingredients.
/// An ingredient has a name, a price (per cl.), 
/// and an alcohol percentage
/// </summary>
public class Ingredient
{
    #region Properties
    public string Name { get; }
    public int PricePerCl { get; }
    public double AlcoholPercent { get; }
    #endregion

    #region Constructor
    public Ingredient(string name, int pricePerCl, double alcoholPercent)
    {
        Name = name;
        PricePerCl = pricePerCl;
        AlcoholPercent = alcoholPercent;
    }
    #endregion
}
