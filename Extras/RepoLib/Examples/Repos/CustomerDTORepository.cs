
/// <summary>
/// DTO-based repository for Customer data.
/// </summary>
public class CustomerDTORepository : JsonRepositoryAppBase<CustomerDTO>
{
    public CustomerDTORepository(bool loadOnCreation = true)
        : base("Customers.json", loadOnCreation)
    {
    }

    /// <summary>
    /// SearchMatch is here defined as a match between the searchTerm
    /// and the Name property
    /// </summary>
    /// <param name="order">CustomerDTO object to test for match</param>
    /// <param name="searchTerm">string to match against CustomerDTO object</param>
    protected override bool SearchMatch(CustomerDTO dto, string searchTerm)
    {
        return dto.Name.Contains(searchTerm); // 
    }

    protected override void UpdateObject(CustomerDTO dtoEx, CustomerDTO dtoNew)
    {
        dtoEx.Name = dtoNew.Name;
        dtoEx.Address = dtoNew.Address;
        dtoEx.Phone = dtoNew.Phone;
    }
}
