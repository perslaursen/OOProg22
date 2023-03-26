
// 1) Setup DB
Setup setup = new Setup("(localdb)\\MSSQLLocalDB", "DrinkDB");


// 2a) Read all Ingredients from the DB, and print them (should print 14 Ingredients)
Helpers.PrintList(setup.IngredientService.GetAll());

// 2b) Read all Cocktails from the DB, and print them (should print 4 Cocktails)
Helpers.PrintList(setup.CocktailService.GetAll());

// 3) Add two new Cocktails
Cocktail c1 = new Cocktail(0, "Plz stop");
c1.AddIngredient(setup.IngredientService.ReadByName("Gin"), 6);
c1.AddIngredient(setup.IngredientService.ReadByName("Vodka"), 6);
c1.AddIngredient(setup.IngredientService.ReadByName("Whiskey"), 6);
setup.CocktailService.Create(c1);

Cocktail c2 = new Cocktail(0, "Easy Going");
c2.AddIngredient(setup.IngredientService.ReadByName("Cola"), 10);
c2.AddIngredient(setup.IngredientService.ReadByName("Sprite"), 10);
c2.AddIngredient(setup.IngredientService.ReadByName("Rum"), 2);
setup.CocktailService.Create(c2);

// 4) Read all Cocktails from the DB again, and print them (should print 6 Cocktails)
Helpers.PrintList(setup.CocktailService.GetAll());

// 5) Delete the two Cocktails just created.
setup.CocktailService.Delete(c1.Id);
setup.CocktailService.Delete(c2.Id);

// 6) Read all Cocktails from the DB again, and print them (should print 6 Cocktails)
Helpers.PrintList(setup.CocktailService.GetAll());
