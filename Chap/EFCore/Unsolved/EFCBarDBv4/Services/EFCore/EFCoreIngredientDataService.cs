
public class EFCoreIngredientDataService : EFCoreDataServiceBase<Ingredient>, IIngredientDataService
{
    /// <summary>
    /// Specific method for EFCoreIngredientDataService
    /// </summary>
    public Ingredient? ReadByName(string name)
    {
        using EFCDrinkDBContext context = new EFCDrinkDBContext();

        return GetAllWithIncludes(context).FirstOrDefault(x => x.Name == name);
    }
}
