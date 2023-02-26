
ItemRepo repo = new ItemRepo();

Console.WriteLine("Clearing...");
repo.Clear();


Console.WriteLine("Adding items...");

repo.Create(new Item("Apple", 2.50));
repo.Create(new Item("Orange", 3.85));
repo.Create(new Item("Carrot", 2.15));
repo.Create(new Item("Pear", 4.25));
repo.Create(new Item("Kiwi", 5.50));
repo.Create(new Item("Lime", 4.70));

Console.WriteLine("Items added!");


Console.WriteLine("All items...");
Console.WriteLine("----------------");
foreach (Item item in repo.GetAll())
{
    Console.WriteLine(item);
}


Console.WriteLine("Deleting...");
repo.Delete(2);
repo.Delete(5);

Console.WriteLine("All items...");
Console.WriteLine("----------------");
foreach (Item item in repo.GetAll())
{
    Console.WriteLine(item);
}



