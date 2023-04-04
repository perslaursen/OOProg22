using Microsoft.EntityFrameworkCore;

public class EFCoreDrinkDataService : EFCoreDataServiceBase<Drink>, IDrinkDataService
{
    /// <summary>
    /// Drink object needs to have AlcoholicPart and NonAlcoholicPart properties resolved.
    /// </summary>
    protected override IQueryable<Drink> GetAllWithIncludes(EFCDrinkDBContext context)
    {
        return context.Set<Drink>()
            .Include(c => c.AlcoholicPart)
            .Include(c => c.NonAlcoholicPart);
    }
}
