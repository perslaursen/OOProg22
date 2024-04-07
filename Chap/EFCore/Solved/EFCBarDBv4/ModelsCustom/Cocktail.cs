
public partial class Cocktail : IHasId
{
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
