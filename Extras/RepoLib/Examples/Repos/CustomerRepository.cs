
public class CustomerRepository : JsonRepositoryBase<Customer, CustomerDTO>
{
    public CustomerRepository(bool loadOnCreation = true)
        : base(loadOnCreation)
    {
    }

    protected override string JsonFileName => @"C:\Users\persl\Documents\GitHubEASJ\OOProg22\Extras\RepoLib\Examples\Data\Customers.json";

    protected override Customer FromDTO(CustomerDTO dto)
    {
        return dto.Convert();
    }

    protected override CustomerDTO ToDTO(Customer t)
    {
        return new CustomerDTO(t);
    }

    protected override bool SearchMatch(Customer t, string searchTerm)
    {
        return t.Name.Contains(searchTerm);
    }

    protected override void UpdateObject(Customer tEx, Customer tNew)
    {
        tEx.Name = tNew.Name;
        tEx.Address = tNew.Address;
        tEx.Phone = tNew.Phone;
    }
}
