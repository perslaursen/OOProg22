
public class CocktailDesolvedRepository : RepositoryBase<CocktailDesolved>
{
    public CocktailDesolvedRepository(string connectionString)
        : base(new DBMethodsForCocktailDesolved(connectionString))
    {
    }
}
