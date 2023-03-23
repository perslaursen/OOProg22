using Microsoft.Data.SqlClient;

// Setup DB
SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "(localdb)\\MSSQLLocalDB";
builder.InitialCatalog = "DrinkDB";


// a) Read all Ingredients from the DB, and print them (should print 14 Ingredients)
DBMethodsForIngredient dbmIng = new DBMethodsForIngredient(builder.ConnectionString);
List<Ingredient> ingredients = dbmIng.ReadAllFromDB();
Helpers.PrintList(ingredients);

// b) Read all Drinks from the DB, and print them (should print 10 Drinks)
DBMethodsForDrink dbmDrink = new DBMethodsForDrink(builder.ConnectionString, dbmIng);
List<Drink> drinks = dbmDrink.ReadAllFromDB();
Helpers.PrintList(drinks);


// c+d) Add new data (two new drinks), and write them to the database
int maxId = drinks.Select(dr => dr.Id).DefaultIfEmpty(0).Max();

Ingredient? gin = ingredients.FirstOrDefault(dr => dr.Name == "Gin");
Ingredient? rum = ingredients.FirstOrDefault(dr => dr.Name == "Rum");
Ingredient? tonic = ingredients.FirstOrDefault(dr => dr.Name == "Tonic");
Ingredient? fanta = ingredients.FirstOrDefault(dr => dr.Name == "Fanta");

if ((gin is not null) && (rum is not null) && (tonic is not null) && (fanta is not null))
{
    Drink d1 = new Drink(maxId + 1, "Gin and Tonic", gin, 3, tonic, 15);
    Drink d2 = new Drink(maxId + 2, "Elefanta", rum, 3, fanta, 20);

    dbmDrink.WriteToDB(d1);
    dbmDrink.WriteToDB(d2);

    // e) Read all drinks from the DB, and print them (should print 12 drinks)
    Helpers.PrintList(dbmDrink.ReadAllFromDB());

    // f) Delete the drinks that were just added to the DB
    dbmDrink.DeleteFromDB(maxId + 1);
    dbmDrink.DeleteFromDB(maxId + 2);


    // g) Read all drinks from the DB, and print them (should print 12 drinks)
    Helpers.PrintList(dbmDrink.ReadAllFromDB());
}