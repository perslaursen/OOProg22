
public class DrinkDataService : IDataService<Drink>
{
    private IRepository<Ingredient> _ingredientRepository;
    private IRepository<DrinkDesolved> _drinkDesolvedRepository;
    public DrinkDataService(
        IRepository<Ingredient> ingredientRepository,
        IRepository<DrinkDesolved> drinkDesolvedRepository)
    {
        _ingredientRepository = ingredientRepository;
        _drinkDesolvedRepository = drinkDesolvedRepository;
    }

    #region Implementation of IService interface

    public int Create(Drink drink)
    {
        int newId = _drinkDesolvedRepository.Create(drink.Desolve());
        drink.Id = newId;
        return newId;
    }

    public Drink? Read(int id)
    {
        return Resolve(_drinkDesolvedRepository.Read(id));
    }

    public bool Delete(int id)
    {
        return _drinkDesolvedRepository.Delete(id);
    }

    public List<Drink> GetAll()
    {
        return _drinkDesolvedRepository.GetAll()
            .Select(dd => Resolve(dd))
            .ToNullFreeList();
    }

    #endregion

    private Drink? Resolve(DrinkDesolved? dd)
    {
        if (dd is null)
            return null;

        Ingredient? alcoPart = ResolveIngredient(dd.AlcoholicPartId);
        Ingredient? nonAlcoPart = ResolveIngredient(dd.NonAlcoholicPartId);

        return new Drink(dd.Id, dd.Name, alcoPart, dd.AlcoholicPartAmount, nonAlcoPart, dd.NonAlcoholicPartAmount);
    }

    private Ingredient? ResolveIngredient(int? ingId)
    {
        if (ingId is null)
            return null;

        return _ingredientRepository.Read(ingId.Value);
    }
}
