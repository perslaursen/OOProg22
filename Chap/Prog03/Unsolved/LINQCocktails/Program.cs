﻿
#region Create ingredients
Ingredient ingVodka = new Ingredient("Vodka", 15, 40);
Ingredient ingRum = new Ingredient("Rum", 15, 40);
Ingredient ingGin = new Ingredient("Gin", 15, 40);
Ingredient ingTripleSec = new Ingredient("Triple Sec", 20, 30);
Ingredient ingCola = new Ingredient("Cola", 1, 0);
Ingredient ingLimeJuice = new Ingredient("Lime Juice", 2, 0);
Ingredient ingCranJuice = new Ingredient("Cranberry Juice", 2, 0);
Ingredient ingGingerBeer = new Ingredient("Ginger Beer", 2, 4);
Ingredient ingMinWater = new Ingredient("Mineral Water", 1, 0);

List<Ingredient> ingredients = new List<Ingredient>
            {
                ingVodka,
                ingRum,
                ingGin,
                ingTripleSec,
                ingCola,
                ingLimeJuice,
                ingCranJuice,
                ingGingerBeer,
                ingMinWater
            };
#endregion

#region Create cocktails
Cocktail c1 = new Cocktail("Long Island Ice Tea");
c1.AddIngredient("Rum", 3);
c1.AddIngredient("Vodka", 3);
c1.AddIngredient("Gin", 3);
c1.AddIngredient("Cola", 9);

Cocktail c2 = new Cocktail("Moscow Mule");
c2.AddIngredient("Vodka", 4);
c2.AddIngredient("Lime Juice", 3);
c2.AddIngredient("Ginger Beer", 10);

Cocktail c3 = new Cocktail("Cosmopolitan");
c3.AddIngredient("Vodka", 4);
c3.AddIngredient("Triple Sec", 2);
c3.AddIngredient("Lime Juice", 6);
c3.AddIngredient("Cranberry Juice", 6);

Cocktail c4 = new Cocktail("Mojito");
c4.AddIngredient("Rum", 4);
c4.AddIngredient("Mineral Water", 10);
c4.AddIngredient("Lime Juice", 2);

List<Cocktail> cocktails = new List<Cocktail> { c1, c2, c3, c4 };

var query = from cocktail in cocktails
            select new {cocktail.Name, cocktail.Ingredients};

foreach (var item in query)
{
    Console.WriteLine($"DrinK: {item.Name} ");
    
    foreach (var item2 in item.Ingredients)
    {
        Console.WriteLine(item2);
    }
}


var innerJoin = from c in cocktails // outer sequence
                join i in ingredients //inner sequence 
                on c.Ingredients equals i.Name // key selector 
                select new { c.Name };
#endregion
