
public partial class Cocktail : IHasId
{
    /// <summary>
    /// This constructor should be used when creating a new object to be managed by EF Core, 
    /// since it does NOT set the navigation properties, but rather sets the corresponding identifiers.
    /// </summary>
    public Cocktail(string name, IEnumerable<CocktailIngredient> ciList)
    {
        Id = 0;
        Name = name;

        CocktailIngredients = ciList.ToHashSet();
    }

    public int Price =>
        CocktailIngredients
            .Select(ing => ing.Ingredient.PricePerCl * ing.AmountInCl)
            .Sum();

    public double AlcoPercent =>
        CocktailIngredients
            .Select(ing => ing.Ingredient.AlcoholPercent * ing.AmountInCl)
            .Sum() / TotalVolume;

    public int TotalVolume =>
        CocktailIngredients
            .Select(ing => ing.AmountInCl)
            .Sum();

    public override string ToString()
    {
        string res = $"[{Id}]  {Name}   ({Price} kr., contains {TotalVolume} cl. of {AlcoPercent:F02} %)\n";
        foreach (CocktailIngredient ing in CocktailIngredients) { res += $"  {ing}\n"; }
        return res;
    }
}
