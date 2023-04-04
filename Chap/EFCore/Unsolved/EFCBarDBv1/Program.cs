
// 0) This is the namespace the auto-generated classes are placed in.
//using EFCBarDBv1;

Console.WriteLine("Test of EFCore Power Tools");
Console.WriteLine();

// 1 +2) Create a context to access the database, read all drinks from the DB,
// and print them (should print 10 drinks)
//using EFCDrinkDBContext context = new EFCDrinkDBContext();
//Helpers.PrintList(context.Drinks);


// 3) Create new data (two new drinks)
//DrinkFlat d1 = new DrinkFlat()
//{
//    Name = "Gin and Tonic",
//    AlcoholicPart = "Gin",
//    AlcoholicPartAmount = 3,
//    NonAlcoholicPart = "Tonic",
//    NonAlcoholicPartAmount = 15
//};

//DrinkFlat d2 = new DrinkFlat()
//{
//    Name = "Gin and Lemon",
//    AlcoholicPart = "Gin",
//    AlcoholicPartAmount = 3,
//    NonAlcoholicPart = "Lemon",
//    NonAlcoholicPartAmount = 20
//};

// 4) Save the new data to the database
//context.Drinks.Add(d1);
//context.Drinks.Add(d2);
//context.SaveChanges();

// 5) Read all drinks from the DB, and print them (should print 12 drinks)
//Helpers.PrintList(context.Drinks);


// 6) Delete the drinks that were just added to the DB
//context.Drinks.Remove(d1);
//context.Drinks.Remove(d2);
//context.SaveChanges();

// 7) Read all drinks from the DB, and print them (should print 10 drinks)
//Helpers.PrintList(context.Drinks);