
public class ProductDataService : IProductDataService
{
    private Dictionary<int, Product> _products;

    public ProductDataService()
    {
        _products = new Dictionary<int, Product>();

        Create(new Product("PC", 6999));
        Create(new Product("Monitor", 2999));
        Create(new Product("Mouse", 449));
        Create(new Product("Keyboard", 679));
    }

    public List<Product> GetAll()
    {
        return _products.Values.ToList();
    }

    public int Create(Product product)
    {
        product.Id = NextId();
        _products[product.Id] = product;

        return product.Id;
    }

    public Product? Read(int id)
    { 
        return _products.ContainsKey(id) ? _products[id] : null; 
    }

    public bool Delete(int id)
    {
        return _products.Remove(id);
    }

    public bool Update(int id, Product product)
    {
        Product? existingProduct = Read(id);
        if (existingProduct == null)
            return false;

        existingProduct.Update(product);

        return true;
    }

    private int NextId() => _products.Keys.DefaultIfEmpty(0).Max() + 1;
}
