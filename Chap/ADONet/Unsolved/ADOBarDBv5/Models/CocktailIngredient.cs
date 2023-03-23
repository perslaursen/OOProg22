
public class CocktailIngredient : IHasId, IDesolvable<CocktailIngredientDesolved>
{
    public int Id { get; set; }
    public Cocktail Cocktail { get; }
    public Ingredient Ingredient { get; }
    public int AmountInCl { get; }

    public CocktailIngredient(int id, Cocktail cocktail, Ingredient? ingredient, int amountInCl)
    {
        if (ingredient is null)
            throw new ArgumentException();

        Id = id;
        Cocktail = cocktail;
        Ingredient = ingredient;
        AmountInCl = amountInCl;
    }

    public override string ToString()
    {
        return $"{AmountInCl} cl. of {Ingredient.Name}";
    }

    public CocktailIngredientDesolved Desolve()
    {
        return new CocktailIngredientDesolved(Id, Cocktail.Id, Ingredient.Id, AmountInCl);
    }
}
