
public class ProductRepository : JsonRepositoryBase<Product, ProductDTO>
{
    public ProductRepository(bool loadOnCreation = true)
        : base(loadOnCreation)
    {
    }

    protected override string JsonFileName => @"C:\Users\persl\Documents\GitHubEASJ\OOProg22\Extras\RepoLib\Examples\Data\Products.json";

    protected override Product FromDTO(ProductDTO dto)
    {
        return dto.Convert();
    }

    protected override ProductDTO ToDTO(Product t)
    {
        return new ProductDTO(t);
    }

    protected override bool SearchMatch(Product t, string searchTerm)
    {
        return t.Description.Contains(searchTerm);
    }

    protected override void UpdateObject(Product tEx, Product tNew)
    {
        tEx.Description = tNew.Description;
        tEx.Price = tNew.Price;
    }
}
