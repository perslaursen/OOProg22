
using Microsoft.EntityFrameworkCore;

public class EFCoreIngredientDataService : EFCoreDataServiceAppBase<Ingredient>, IIngredientDataService
{
    /// <summary>
    /// Specific method for EFCoreIngredientDataService
    /// </summary>
    public Ingredient? ReadByName(string name)
    {
        using DbContext context = CreateDbContext();

        return GetAllWithIncludes(context).FirstOrDefault(x => x.Name == name);
    }
}
