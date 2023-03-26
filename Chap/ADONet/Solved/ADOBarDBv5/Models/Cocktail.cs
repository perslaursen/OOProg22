
public class Cocktail : IHasId, IDesolvable<CocktailDesolved>
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; }
    public List<CocktailIngredient> Ingredients { get; }

    public int Price => 
        Ingredients
            .Select(ing => ing.Ingredient.PricePerCl * ing.AmountInCl)
            .Sum();

    public double AlcoPercent =>
        Ingredients
            .Select(ing => ing.Ingredient.AlcoholPercent * ing.AmountInCl)
            .Sum() / TotalVolume;

    public int TotalVolume => 
        Ingredients
            .Select(ing => ing.AmountInCl)
            .Sum();

    #endregion

    public Cocktail(int id, string name)
    {
        Id = id;
        Name = name;
        Ingredients = new List<CocktailIngredient>();
    }

    public void AddIngredient(Ingredient? ingredient, int amount)
    {
        if (ingredient == null)
            throw new ArgumentException();

        Ingredients.Add(new CocktailIngredient(0, this, ingredient, amount));
    }

    public override string ToString() 
    {
        string res = $"[{Id}]  {Name}   ({Price} kr., contains {TotalVolume} cl. of {AlcoPercent:F02} %)\n";
        foreach (CocktailIngredient ing in Ingredients) { res += $"  {ing}\n"; }
        return res;
    }

    public CocktailDesolved Desolve()
    {
        return new CocktailDesolved(Id, Name);
    }
}
