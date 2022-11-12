
public class PizzaRepository : RepositoryBase<Pizza>
{
    public PizzaRepository()
    {
        Pizza p1 = Create();
        p1.Description = "Test Pizza A";
        p1.Price = 85;

        Pizza p2 = Create();
        p2.Description = "Test Pizza B";
        p2.Price = 75;

        Pizza p3 = Create();
        p3.Description = "Test Pizza C";
        p3.Price = 90;
    }

    /// <summary>
    /// A match is for Pizza defined as a match on the Description property
    /// </summary>
    protected override bool SearchMatch(Pizza pizza, string searchTerm)
    {
        return pizza.Description.ToLower().Contains(searchTerm.ToLower());
    }
}
