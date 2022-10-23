
Console.WriteLine("Begin");

bool doInlineInit = false;
DataRepository dataRepo = new DataRepository(!doInlineInit);

if (doInlineInit)
{
    InitCustomerRepo();
    InitProductRepo();
    InitOrderRepo();
}

Console.WriteLine(dataRepo.GetCustomersAsString());
Console.WriteLine(dataRepo.GetProductsAsString());
Console.WriteLine(dataRepo.GetOrdersAsString());



void InitProductRepo()
{
    dataRepo.CreateProduct("Product A", 150, 1);
    dataRepo.CreateProduct("Product B", 230, 2);
    dataRepo.CreateProduct("Product C", 385, 3);

    dataRepo.SaveProducts();
}

void InitCustomerRepo()
{
    dataRepo.CreateCustomer("Anders", "51 09 12 90", "Stien 12", 1);
    dataRepo.CreateCustomer("Benny", "41 29 59 02", "Skolevej 33", 2);
    dataRepo.CreateCustomer("Carina", "47 01 07 88", "Markvej 5", 3);

    dataRepo.SaveCustomers();
}

void InitOrderRepo()
{
    dataRepo.CreateOrder(1, new List<int> { 1, 2} );
    dataRepo.CreateOrder(3, new List<int> { 2, 3 });
    dataRepo.CreateOrder(1, new List<int> { 1, 3 });

    dataRepo.SaveOrders();
}