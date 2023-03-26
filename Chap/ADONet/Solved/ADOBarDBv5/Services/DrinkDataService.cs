
public class DrinkDataService : IDataService<Drink>
{
    private IRepository<Ingredient> _ingRepo;
    private IRepository<DrinkDesolved> _ddRepo;

    public DrinkDataService(
        IRepository<Ingredient> ingRepo,
        IRepository<DrinkDesolved> ddRepo)
    {
        _ingRepo = ingRepo;
        _ddRepo = ddRepo;
    }

    #region Implementation of IDataService interface

    public int Create(Drink drink)
    {
        int newId = _ddRepo.Create(drink.Desolve());
        drink.Id = newId;
        return newId;
    }

    public Drink? Read(int id)
    {
        return Resolve(_ddRepo.Read(id));
    }

    public bool Delete(int id)
    {
        return _ddRepo.Delete(id);
    }

    public List<Drink> GetAll()
    {
        return _ddRepo.GetAll()
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

        return new Drink(dd.Id, dd.Name, 
            alcoPart, dd.AlcoholicPartAmount, 
            nonAlcoPart, dd.NonAlcoholicPartAmount);
    }

    private Ingredient? ResolveIngredient(int? ingId)
    {
        if (ingId is null)
            return null;

        return _ingRepo.Read(ingId.Value);
    }
}
