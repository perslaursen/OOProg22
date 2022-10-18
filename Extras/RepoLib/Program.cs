
Console.WriteLine("Begin");

DataRepository dataRepo = new DataRepository();
Console.WriteLine(dataRepo.CustomerRepo);
Console.WriteLine(dataRepo.ProductRepo);
Console.WriteLine(dataRepo.OrderRepo);

//ProductRepository productRepo = new ProductRepository(false);

//productRepo.Create(new Product("Product A", 100));
//productRepo.Create(new Product("Product B", 100));
//productRepo.Create(new Product("Product C", 100));

//Console.WriteLine(productRepo);

//productRepo.Save();



//CustomerRepository customerRepo = new CustomerRepository(false);

//customerRepo.Create(new Customer("Anders", "51 09 12 90", "Stien 12"));
//customerRepo.Create(new Customer("Benny", "41 29 59 02", "Skolevej 33"));
//customerRepo.Create(new Customer("Carina", "47 01 07 88", "Markvej 5"));

//Console.WriteLine(customerRepo);

//customerRepo.Save();



//List<Product> prodList1 = new List<Product> { productRepo.Read(1), productRepo.Read(2) };
//List<Product> prodList2 = new List<Product> { productRepo.Read(2), productRepo.Read(3) };

//Order order1 = new Order(customerRepo.Read(1), prodList1);
//Order order2 = new Order(customerRepo.Read(3), prodList2);
//Order order3 = new Order(customerRepo.Read(1), prodList2);

//OrderRepository orderRepo = new OrderRepository(customerRepo, productRepo, false);
//orderRepo.Create(order1);
//orderRepo.Create(order2);
//orderRepo.Create(order3);

//Console.WriteLine(orderRepo);

//orderRepo.Save();
