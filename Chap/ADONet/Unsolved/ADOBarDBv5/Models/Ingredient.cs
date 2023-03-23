
/// <summary>
/// This class represents a drink/cocktail ingredient, limited to liquid ingredients.
/// An ingredient has a name, a price (per cl.), and an alcohol percentage.
/// </summary>
public class Ingredient : IHasId
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; }
    public int PricePerCl { get; }
    public double AlcoholPercent { get; }
    
    #endregion

    #region Constructor
    
    public Ingredient(int id, string name, int pricePerCl, double alcoholPercent)
    {
        Id = id;
        Name = name;
        PricePerCl = pricePerCl;
        AlcoholPercent = alcoholPercent;
    }

    public override string ToString()
    {
        return $"[{Id,2}]  {Name} ({AlcoholPercent:F02} %, costs {PricePerCl} kr. per cl.)";
    }

    #endregion
}
