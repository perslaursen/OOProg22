
using Microsoft.EntityFrameworkCore;

public partial class EFCDrinkDBContext : IDrinkDataService, IIngredientDataService
{
    #region Implementation of IDrinkDataService interface 
    
    int IDataService<Drink>.Create(Drink t) => Create(t);
    Drink? IDataService<Drink>.Read(int id) => GetAllDrinks().FirstOrDefault(t => t.Id == id);
    bool IDataService<Drink>.Delete(int id) => Delete<Drink>(id);
    List<Drink> IDataService<Drink>.GetAll() => GetAllDrinks().ToList();

    #endregion

    #region Implementation of IIngredientDataService interface 
    
    int IDataService<Ingredient>.Create(Ingredient t) => Create(t);
    Ingredient? IDataService<Ingredient>.Read(int id) => GetAllIngredients().FirstOrDefault(t => t.Id == id);
    bool IDataService<Ingredient>.Delete(int id) => Delete<Ingredient>(id);
    List<Ingredient> IDataService<Ingredient>.GetAll() => GetAllIngredients().ToList();  
    public Ingredient? ReadByName(string name) => GetAllIngredients().FirstOrDefault(x => x.Name == name);

    #endregion


    #region Generic helper methods
    
    private int Create<T>(T t) where T : class, IHasId
    {
        Set<T>().Add(t);
        SaveChanges();

        return t.Id;
    }

    private bool Delete<T>(int id) where T : class
    {

        T? tEx = Set<T>().Find(id);
        if (tEx == null)
            return false;

        Set<T>().Remove(tEx);
        return (SaveChanges() > 0);
    }

    #endregion

    #region Type-specific GetAll... methods
    
    private IQueryable<Drink> GetAllDrinks()
    {
        return Set<Drink>()
            .Include(c => c.AlcoholicPart)
            .Include(c => c.NonAlcoholicPart);
    }

    private IQueryable<Ingredient> GetAllIngredients()
    {
        return Set<Ingredient>();
    } 

    #endregion
}
