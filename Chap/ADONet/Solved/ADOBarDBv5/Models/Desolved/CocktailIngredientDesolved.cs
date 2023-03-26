
public class CocktailIngredientDesolved : IHasId
{
    #region Properties

    public int Id { get; set; }
    public int CocktailId { get; set;}
    public int IngredientId { get; }
    public int AmountInCl{ get; }
    
    #endregion

    public CocktailIngredientDesolved(int id, int cocktailId, int ingredientId, int amountInCl)
    {
        Id = id;
        CocktailId = cocktailId;
        IngredientId = ingredientId;
        AmountInCl = amountInCl;
    }
}
