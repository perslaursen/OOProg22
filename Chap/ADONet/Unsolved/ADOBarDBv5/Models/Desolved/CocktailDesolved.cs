
public class CocktailDesolved : IHasId
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; }

    #endregion

    public CocktailDesolved(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
