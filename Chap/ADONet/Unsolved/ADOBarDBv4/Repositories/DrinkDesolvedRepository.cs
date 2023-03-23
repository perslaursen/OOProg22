
public class DrinkDesolvedRepository : RepositoryBase<DrinkDesolved>
{
    public DrinkDesolvedRepository(string connectionString) 
        : base(new DBMethodsForDrinkDesolved(connectionString))
    {
    }
}
