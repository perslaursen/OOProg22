
/// <summary>
/// Customer repository. Provides some test data, and implements Searchmatch.
/// </summary>
public class CustomerRepository : RepositoryBase<Customer>
{
    public CustomerRepository()
    {
        Customer c1 = Create();
        c1.Name = "Albert E.";
        c1.Address = "Skovvej 120";
        c1.Phone = "51 00 17 65";

        Customer c2 = Create();
        c2.Name = "Benny H.";
        c2.Address = "Ved Søen 34";
        c2.Phone = "52 09 12 54";

        Customer c3 = Create();
        c3.Name = "Carina L.";
        c3.Address = "Stien 17";
        c3.Phone = "54 92 03 32";
    }

    /// <summary>
    /// A match is for Customer defined as a match on the Description property
    /// </summary>
    protected override bool SearchMatch(Customer customer, string searchTerm)
    {
        return customer.Name.ToLower().Contains(searchTerm.ToLower()); 
    }
}
