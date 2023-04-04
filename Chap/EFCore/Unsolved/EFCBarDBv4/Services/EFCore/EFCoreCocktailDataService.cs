
using Microsoft.EntityFrameworkCore;

public class EFCoreCocktailDataService : EFCoreDataServiceBase<Cocktail>, ICocktailDataService
{
    protected override IQueryable<Cocktail> GetAllWithIncludes(EFCDrinkDBContext context)
    {
        return context.Set<Cocktail>()
            .Include(c => c.CocktailIngredients)
                .ThenInclude(ci => ci.Ingredient);
    }
}
