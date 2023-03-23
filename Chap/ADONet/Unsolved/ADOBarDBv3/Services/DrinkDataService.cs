
public class DrinkDataService : DataServiceBase<Drink>
{
    public DrinkDataService(string connectionString)
        : base(new DBMethodsForDrink(connectionString, new DBMethodsForIngredient(connectionString)))
    {
    }
}
