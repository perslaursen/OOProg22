
public class DataRepository
{
    public CustomerRepository CustomerRepo { get; }  
    public ProductRepository ProductRepo { get; }
    public OrderRepository OrderRepo { get; }

    public DataRepository(bool loadOnCreate = true)
    {
        CustomerRepo = new CustomerRepository(loadOnCreate);
        ProductRepo = new ProductRepository(loadOnCreate);
        OrderRepo = new OrderRepository(CustomerRepo, ProductRepo, loadOnCreate);
    }

    public void Load()
    {
        CustomerRepo.Load();
        ProductRepo.Load();
        OrderRepo.Load();
    }

    public void Save()
    {
        CustomerRepo.Save();
        ProductRepo.Save();
        OrderRepo.Save();
    }

    public void Clear()
    {
        CustomerRepo.Clear();
        ProductRepo.Clear();
        OrderRepo.Clear();
    }
}
