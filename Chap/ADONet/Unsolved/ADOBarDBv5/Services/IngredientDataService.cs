
public class IngredientDataService : DataServiceBase<Ingredient>
{
    public IngredientDataService(IRepository<Ingredient> repository) 
        : base(repository)
    {
    }

    /// <summary>
    /// Specific method for IngredientService
    /// </summary>
    public Ingredient? ReadByName(string name)
    {
        return _repository.GetAll().FirstOrDefault(x => x.Name == name);
    }
}
