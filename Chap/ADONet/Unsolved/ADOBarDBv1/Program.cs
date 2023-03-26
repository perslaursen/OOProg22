using Microsoft.Data.SqlClient;

// 1) Setup DB
SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "(localdb)\\MSSQLLocalDB";
builder.InitialCatalog = "DrinkDB";


// 2) Read all drinks from the DB, and print them (should print 10 drinks)
DBMethodsForDrink dbMethods = new DBMethodsForDrink(builder.ConnectionString);
List<Drink> drinks = dbMethods.ReadAllFromDB();
Helpers.PrintDrinkList(drinks);


// 3) Add new data (two new drinks), and write them to the database
int maxId = drinks.Select(dr => dr.Id).DefaultIfEmpty(0).Max();

Drink d1 = new Drink(maxId + 1, "Gin and Tonic", "Gin", 3, "Tonic", 15);
Drink d2 = new Drink(maxId + 2, "Gin and Lemon", "Gin", 3, "Tonic", 20);

dbMethods.WriteToDB(d1);
dbMethods.WriteToDB(d2);


// 4) Read all drinks from the DB, and print them (should print 12 drinks)
Helpers.PrintDrinkList(dbMethods.ReadAllFromDB());


// 5) Delete the drinks that were just added to the DB
dbMethods.DeleteFromDB(maxId + 1);
dbMethods.DeleteFromDB(maxId + 2);


// 6) Read all drinks from the DB, and print them (should print 10 drinks)
Helpers.PrintDrinkList(dbMethods.ReadAllFromDB());
