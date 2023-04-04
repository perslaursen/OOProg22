
public class EFCoreIngredientDataService : EFCoreDataServiceBase<Ingredient>, IIngredientDataService
{
    /// <summary>
    /// Specific method for EFCoreIngredientDataService
    /// </summary>
    public Ingredient? ReadByName(string name)
    {
        return GetAll().FirstOrDefault(x => x.Name == name);
    }
}
