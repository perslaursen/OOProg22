
using Microsoft.EntityFrameworkCore;

public class EFCoreCocktailDataService : EFCoreDataServiceAppBase<Cocktail>, ICocktailDataService
{
    /// <summary>
    /// Cocktail object needs to have all CocktailIngredient object references resolved.
    /// Each CocktailIngredient needs to have Ingredient object reference resolved.
    /// </summary>
    protected override IQueryable<Cocktail> GetAllWithIncludes(DbContext context)
    {
        return context.Set<Cocktail>()
            .Include(c => c.CocktailIngredients)
                .ThenInclude(ci => ci.Ingredient);
    }
}
