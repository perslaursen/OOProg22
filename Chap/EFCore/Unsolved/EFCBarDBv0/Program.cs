
// 1) Create a context to access the database
using DrinkDBContext context = new DrinkDBContext();

// 2) Read all drinks from the DB, and print them (should print 10 drinks)
foreach (DrinkFlat drink in context.Drinks)
{
    Console.WriteLine(drink);
}
