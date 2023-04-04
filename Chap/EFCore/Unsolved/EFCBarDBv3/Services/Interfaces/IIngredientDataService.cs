
public interface IIngredientDataService : IDataService<Ingredient>
{
    Ingredient? ReadByName(string name);
}