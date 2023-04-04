
Console.WriteLine("Test of IDataService interfaces");
Console.WriteLine();


// 1a) Use the data service interface implementations directly on EFCDrinkDBContext 
//EFCDrinkDBContext context = new EFCDrinkDBContext();
//IDrinkDataService drinkDataService = context;
//IIngredientDataService  ingDataService = context;

// or

// 1b) Use the data service interface implementations on EFCCore... classes
IIngredientDataService ingDataService = new EFCoreIngredientDataService();
IDrinkDataService drinkDataService = new EFCoreDrinkDataService();

// Read all ingredients drinks from the database, and print them
// (should print 14 ingredients and 10 drinks)
Helpers.PrintList(ingDataService.GetAll());
Helpers.PrintList(drinkDataService.GetAll());

// Create new data (two new drinks)
Drink d1 = new Drink(
    "Gin and Tonic", 
    ingDataService.ReadByName("Gin")?.Id, 3, 
    ingDataService.ReadByName("Tonic")?.Id, 15);
Drink d2 = new Drink(
    "Elefanta", 
    ingDataService.ReadByName("Rum")?.Id, 3, 
    ingDataService.ReadByName("Fanta")?.Id, 20);

// Save the new data to the database
drinkDataService.Create(d1);
drinkDataService.Create(d2);

// Read all drinks from the database, and print them (should print 12 drinks)
Helpers.PrintList(drinkDataService.GetAll());

// Delete the drinks that were just added to the database
drinkDataService.Delete(d1.Id);
drinkDataService.Delete(d2.Id);

// Read all drinks from the database, and print them (should print 10 drinks)
Helpers.PrintList(drinkDataService.GetAll());
