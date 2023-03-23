
public class CocktailDataService : IDataService<Cocktail>
{
    private IngredientRepository _ingredientRepository;
    private CocktailDesolvedRepository _cocktailDesolvedRepository;
    private CocktailIngredientDesolvedRepository _cocktailIngredientDesolvedRepository;

    public CocktailDataService(
        IngredientRepository ingredientRepo,
        CocktailDesolvedRepository cocktailRepo,
        CocktailIngredientDesolvedRepository cocktailIngredientRepo)
    {
        _ingredientRepository = ingredientRepo;
        _cocktailDesolvedRepository = cocktailRepo;
        _cocktailIngredientDesolvedRepository = cocktailIngredientRepo;
    }

    public int Create(Cocktail c)
    {
        // 1) Create cocktail ítself
        int newId = _cocktailDesolvedRepository.Create(c.Desolve());
        c.Id = newId;

        // 2) Create all ingredients in this specific cocktail
        c.Ingredients.ForEach(ci => { ci.Id = _cocktailIngredientDesolvedRepository.Create(ci.Desolve()); }); 

        return newId;
    }

    public bool Delete(int id)
    {
        // 1) Delete cocktail ítself
        bool deleted = _cocktailDesolvedRepository.Delete(id);

        if (!deleted)
            return false;

        // 2) Delete all cocktail-ingredients associated with the deleted cocktail.
        GetAllIngredientsForCocktail(id)
            .ForEachOnEnumerable(ci => _cocktailIngredientDesolvedRepository.Delete(ci.Id));

        return true;
    }

    public List<Cocktail> GetAll()
    {
        return _cocktailDesolvedRepository.GetAll()
            .Select(cd => Resolve(cd))
            .ToNullFreeList();
    }

    public Cocktail? Read(int id)
    {
       return Resolve(_cocktailDesolvedRepository.Read(id));
    }

    private Cocktail? Resolve(CocktailDesolved? cd)
    {
        if (cd is null)
            return null;

        Cocktail c = new Cocktail(cd.Id, cd.Name);

        GetAllIngredientsForCocktail(c.Id)
            .Select(cid => new { Ingredient = _ingredientRepository.Read(cid.IngredientId), cid.AmountInCl })
            .ForEachOnEnumerable(coIng => c.AddIngredient(coIng.Ingredient, coIng.AmountInCl));

        return c;
    }

    private IEnumerable<CocktailIngredientDesolved> GetAllIngredientsForCocktail(int cocktailId)
    {
        return _cocktailIngredientDesolvedRepository.GetAll()
            .Where(cid => cid.CocktailId == cocktailId);
    }
}
