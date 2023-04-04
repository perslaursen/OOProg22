
using System.Xml.Linq;

public partial class CocktailIngredient : IHasId
{
    /// <summary>
    /// This constructor should be used when creating a new object to be managed by EF Core, 
    /// since it does NOT set the navigation properties, but rather sets the corresponding identifiers.
    /// </summary>
    public CocktailIngredient(int ingredientId, int amountInCl)
    {
        Id = 0;
        CocktailId = 0;
        IngredientId = ingredientId;
        AmountInCl = amountInCl;
    }

    public override string ToString()
    {
        return $"{AmountInCl} cl. of {Ingredient.Name}";
    }
}
