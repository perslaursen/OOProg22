
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Test of EFCore, two related tables");
Console.WriteLine();


// 1) Create a context to access the database
//using EFCDrinkDBContext context = new EFCDrinkDBContext();

// 2a) Read all drinks from the DB, and print them (should print 10 drinks)
//var drinksNoInclude =
//    context.Drinks;

//Helpers.PrintList(drinksNoInclude, "(without Include)");


// 2b) Read all drinks from the DB, and print them (should print 10 drinks)
//var drinksWithInclude =
//    context.Drinks
//        .Include("AlcoholicPart")
//        .Include("NonAlcoholicPart");

//Helpers.PrintList(drinksWithInclude, "(with Include)");
