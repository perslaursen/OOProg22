
/// <summary>
/// This class represents a cocktail, which is simply
/// a name, and a list of ingredients.
/// For each ingredient, the name and amount (in cl.) 
/// is specified
/// </summary>
public class Cocktail
{
    #region Properties
    public string Name { get; }
    public Dictionary<string, int> Ingredients { get; }
    #endregion

    #region Constructor
    public Cocktail(string name)
    {
        Name = name;
        Ingredients = new Dictionary<string, int>();
    }
    #endregion

    #region Methods
    public void AddIngredient(string ingredientName, int amount)
    {
        Ingredients.Add(ingredientName, amount);
    }
    #endregion
}
