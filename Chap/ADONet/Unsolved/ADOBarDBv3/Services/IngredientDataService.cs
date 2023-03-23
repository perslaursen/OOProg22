
public class IngredientDataService : DataServiceBase<Ingredient>
{
    public IngredientDataService(string connectionString) 
        : base(new DBMethodsForIngredient(connectionString))
    {
    }

    /// <summary>
    /// Specific method for IngredientService
    /// </summary>
    public Ingredient? ReadByName(string name)
    {
        return _dbMethods.ReadAllFromDB($"Name = '{name}'").FirstOrDefault();
    }
}
