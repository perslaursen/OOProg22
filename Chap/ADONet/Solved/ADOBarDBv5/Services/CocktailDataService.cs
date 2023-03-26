
public class CocktailDataService : IDataService<Cocktail>
{
    private IRepository<Ingredient> _ingRepo;
    private IRepository<CocktailDesolved> _cdRepo;
    private IRepository<CocktailIngredientDesolved> _cidRepo;

    public CocktailDataService(
        IRepository<Ingredient> ingRepo,
        IRepository<CocktailDesolved> cdRepo,
        IRepository<CocktailIngredientDesolved> cidRepo)
    {
        _ingRepo = ingRepo;
        _cdRepo = cdRepo;
        _cidRepo = cidRepo;
    }

    #region Implementation of IDataService interface
    
    public int Create(Cocktail c)
    {
        // 1) Create cocktail ítself
        int newId = _cdRepo.Create(c.Desolve());
        c.Id = newId;

        // 2) Create all ingredients in this specific cocktail
        c.Ingredients.ForEach(ci => { ci.Id = _cidRepo.Create(ci.Desolve()); });

        return newId;
    }

    public Cocktail? Read(int id)
    {
        return Resolve(_cdRepo.Read(id));
    }

    public bool Delete(int id)
    {
        // 1) Delete cocktail ítself
        bool deleted = _cdRepo.Delete(id);

        if (!deleted)
            return false;

        // 2) Delete all cocktail-ingredients associated with the deleted cocktail.
        GetAllIngredientsForCocktail(id)
            .ForEachOnEnumerable(ci => _cidRepo.Delete(ci.Id));

        return true;
    }

    public List<Cocktail> GetAll()
    {
        return _cdRepo.GetAll()
            .Select(cd => Resolve(cd))
            .ToNullFreeList();
    }

    #endregion

    private Cocktail? Resolve(CocktailDesolved? cd)
    {
        if (cd is null)
            return null;

        Cocktail c = new Cocktail(cd.Id, cd.Name);

        GetAllIngredientsForCocktail(c.Id)
            .Select(cid => new { Ingredient = _ingRepo.Read(cid.IngredientId), cid.AmountInCl })
            .ForEachOnEnumerable(ingAm => c.AddIngredient(ingAm.Ingredient, ingAm.AmountInCl));

        return c;
    }

    private IEnumerable<CocktailIngredientDesolved> GetAllIngredientsForCocktail(int cocktailId)
    {
        return _cidRepo.GetAll()
            .Where(cid => cid.CocktailId == cocktailId);
    }
}
