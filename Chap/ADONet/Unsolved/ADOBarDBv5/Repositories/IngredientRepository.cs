
public class IngredientRepository : RepositoryBase<Ingredient>
{
    public IngredientRepository(string connectionString) 
        : base(new DBMethodsForIngredient(connectionString))
    {
    }
}
