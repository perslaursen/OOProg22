
// 1) Setup DB
Setup setup = new Setup("(localdb)\\MSSQLLocalDB", "DrinkDB");


// 2a) Read all Ingredients from the DB, and print them (should print 14 Ingredients)
List<Ingredient> ingredients = setup.IngredientService.GetAll();
Helpers.PrintList(ingredients);

// 2b) Read all Cocktails from the DB, and print them (should print 10 Drinks)
List<Cocktail> cocktails = setup.CocktailService.GetAll();
Helpers.PrintList(cocktails);

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

Helpers.PrintList(setup.CocktailService.GetAll());

// Delete data
setup.CocktailService.Delete(c1.Id);
setup.CocktailService.Delete(c2.Id);
Helpers.PrintList(setup.CocktailService.GetAll());
