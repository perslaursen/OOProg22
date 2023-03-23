using Microsoft.Data.SqlClient;

// 1) Setup DB
SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "(localdb)\\MSSQLLocalDB";
builder.InitialCatalog = "DrinkDB";


// 2a) Read all Ingredients from the DB, and print them (should print 14 Ingredients)
IngredientDataService idService = new IngredientDataService(builder.ConnectionString);
List<Ingredient> ingredients = idService.GetAll();
Helpers.PrintList(ingredients);

// 2b) Read all Drinks from the DB, and print them (should print 10 Drinks)
DrinkDataService ddService = new DrinkDataService(builder.ConnectionString);
List<Drink> drinks = ddService.GetAll();
Helpers.PrintList(drinks);


//// 3) Add new data (two new drinks), and write them to the database
Ingredient? gin = idService.ReadByName("Gin");
Ingredient? rum = idService.ReadByName("Rum");
Ingredient? tonic = idService.ReadByName("Tonic");
Ingredient? fanta = idService.ReadByName("Fanta");

if ((gin is not null) && (rum is not null) && (tonic is not null) && (fanta is not null))
{
    Drink d1 = new Drink(0, "Gin and Tonic", gin, 3, tonic, 15);
    Drink d2 = new Drink(0, "Elefanta", rum, 3, fanta, 20);

    ddService.Create(d1);
    ddService.Create(d2);

    // 4) Read all drinks from the DB, and print them (should print 12 drinks)
    Helpers.PrintList(ddService.GetAll());

    //// 5) Delete the drinks that were just added to the DB
    ddService.Delete(d1.Id);
    ddService.Delete(d2.Id);

    //// 6) Read all drinks from the DB, and print them (should print 12 drinks)
    Helpers.PrintList(ddService.GetAll());
}
