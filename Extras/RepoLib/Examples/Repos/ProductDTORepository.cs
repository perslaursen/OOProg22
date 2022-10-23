
/// <summary>
/// DTO-based repository for Product data.
/// </summary>
public class ProductDTORepository : JsonRepositoryAppBase<ProductDTO>
{
    public ProductDTORepository(bool loadOnCreation = true)
        : base("Products.json", loadOnCreation)
    {
    }

    /// <summary>
    /// SearchMatch is here defined as a match between the searchTerm
    /// and the Description property
    /// </summary>
    /// <param name="order">ProductDTO object to test for match</param>
    /// <param name="searchTerm">string to match against ProductDTO object</param>
    protected override bool SearchMatch(ProductDTO dto, string searchTerm)
    {
        return dto.Description.Contains(searchTerm);
    }

    protected override void UpdateObject(ProductDTO dtoEx, ProductDTO dtoNew)
    {
        dtoEx.Description = dtoNew.Description;
        dtoEx.Price = dtoNew.Price;
    }
}
