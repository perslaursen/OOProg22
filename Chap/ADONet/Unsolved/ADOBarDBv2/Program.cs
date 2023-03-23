using Microsoft.Data.SqlClient;

// Setup DB
SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "(localdb)\\MSSQLLocalDB";
builder.InitialCatalog = "DrinkDB";


// a) Read all Ingredients from the DB, and print them (should print 14 Ingredients)

// b) Read all Drinks from the DB, and print them (should print 10 Drinks)

// c+d) Add new data (two new drinks), and write them to the database

// e) Read all drinks from the DB, and print them (should print 12 drinks)

// f) Delete the drinks that were just added to the DB

// g) Read all drinks from the DB, and print them (should print 12 drinks)
