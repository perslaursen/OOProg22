
public class CocktailIngredientDesolvedRepository : RepositoryBase<CocktailIngredientDesolved>
{
    public CocktailIngredientDesolvedRepository(string connectionString)
        : base(new DBMethodsForCocktailIngredientDesolved(connectionString))
    {
    }
}
