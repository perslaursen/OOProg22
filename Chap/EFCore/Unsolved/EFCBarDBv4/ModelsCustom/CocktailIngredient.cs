
using System.Xml.Linq;

public partial class CocktailIngredient : IHasId
{
    public override string ToString()
    {
        return $"{AmountInCl} cl. of {Ingredient.Name}";
    }
}
