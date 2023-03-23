
// 1) Setup DB
Setup setup = new Setup("(localdb)\\MSSQLLocalDB", "DrinkDB");


// 2a) Read all Ingredients from the DB, and print them (should print 14 Ingredients)
List<Ingredient> ingredients = setup.IngredientService.GetAll();
Helpers.PrintList(ingredients);

// 2b) Read all Drinks from the DB, and print them (should print 10 Drinks)
List<Drink> drinks = setup.DrinkService.GetAll();
Helpers.PrintList(drinks);


//// 3) Add new data (two new drinks), and write them to the database
Ingredient? gin = setup.IngredientService.ReadByName("Gin");
Ingredient? rum = setup.IngredientService.ReadByName("Rum");
Ingredient? tonic = setup.IngredientService.ReadByName("Tonic");
Ingredient? fanta = setup.IngredientService.ReadByName("Fanta");

if ((gin is not null) && (rum is not null) && (tonic is not null) && (fanta is not null))
{
    Drink d1 = new Drink(0, "Gin and Tonic", gin, 3, tonic, 15);
    Drink d2 = new Drink(0, "Elefanta", rum, 3, fanta, 20);

    setup.DrinkService.Create(d1);
    setup.DrinkService.Create(d2);

    // 4) Read all drinks from the DB, and print them (should print 12 drinks)
    Helpers.PrintList(setup.DrinkService.GetAll());

    //// 5) Delete the drinks that were just added to the DB
    setup.DrinkService.Delete(d1.Id);
    setup.DrinkService.Delete(d2.Id);

    //// 6) Read all drinks from the DB, and print them (should print 12 drinks)
    Helpers.PrintList(setup.DrinkService.GetAll());
}

