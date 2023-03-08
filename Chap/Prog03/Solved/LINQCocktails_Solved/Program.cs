
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
#endregion

#region Query #1
var queryResult1 = 
    from c in cocktails
    select c.Name;

Console.WriteLine("#1");
Console.WriteLine("------------------");
foreach (var element in queryResult1)
{
    Console.WriteLine($"{element}");
}
Console.WriteLine();
#endregion

#region Query #2
var queryResult2 = 
    from c in cocktails
    select new
    {
        c.Name,
        Data = c.Ingredients.Select(e => $"{e.Key} {e.Value} cl.")
    };

Console.WriteLine("#2");
Console.WriteLine("------------------");
foreach (var element in queryResult2)
{
    Console.WriteLine($"{element.Name}");
    foreach (var collElement in element.Data)
    {
        Console.WriteLine($"  {collElement}");
    }
    Console.WriteLine();
}
Console.WriteLine();
#endregion

#region Query #3
var queryResult3a = 
    from c in cocktails
    select new
    {
        c.Name,
        Data = from coIng in c.Ingredients
               join ing in ingredients
               on coIng.Key equals ing.Name
               where ing.AlcoholPercent > 10
               select ing.Name
    };

var queryResult3b = cocktails.Select(c => new
    {
        c.Name,
        Data = c.Ingredients
            .Join(ingredients.Where(ing => ing.AlcoholPercent > 10),
                  coIng => coIng.Key,
                  ing => ing.Name,
                  (coIng, ing) => ing.Name)
    });

Console.WriteLine("#3");
Console.WriteLine("------------------");
foreach (var element in queryResult3a)
{
    Console.WriteLine($"{element.Name}");
    foreach (var collElement in element.Data)
    {
        Console.WriteLine($"  {collElement}");
    }
    Console.WriteLine();
}
Console.WriteLine();
#endregion

#region Query #4
var queryResult4a = 
    from c in cocktails
    select new
    {
        c.Name,
        Price = (from coIng in c.Ingredients
                 join ing in ingredients
                 on coIng.Key equals ing.Name
                 select coIng.Value * ing.PricePerCl).Sum()
    };

var queryResult4b = cocktails.Select(c => new
    {
        c.Name,
        Price = c.Ingredients
            .Join(ingredients,
                  coIng => coIng.Key,
                  ing => ing.Name,
                  (coIng, ing) => coIng.Value * ing.PricePerCl).Sum()
    });

Console.WriteLine("#4");
Console.WriteLine("------------------");
foreach (var element in queryResult4a)
{
    Console.WriteLine($"{element.Name,-25}: {element.Price,4} kr.");
}
Console.WriteLine();
#endregion

#region Query #5
var queryResult5a = 
    from c in cocktails
    select new
    {
        c.Name,
        Strength = (from coIng in c.Ingredients
                    join ing in ingredients
                    on coIng.Key equals ing.Name
                    select coIng.Value * ing.AlcoholPercent).Sum() /
                   (from coIng in c.Ingredients
                    join ing in ingredients
                    on coIng.Key equals ing.Name
                    select coIng.Value).Sum()
    };

var queryResult5b = cocktails.Select(c => new
    {
        c.Name,
        Strength = c.Ingredients.Join(
                        ingredients, 
                        coIng => coIng.Key, 
                        ing => ing.Name, 
                        (coIng, ing) => coIng.Value * ing.AlcoholPercent).Sum() / 
                   c.Ingredients.Join(
                       ingredients, 
                       coIng => coIng.Key, 
                       ing => ing.Name, 
                       (coIng, ing) => coIng.Value).Sum()
    });

Console.WriteLine("#5");
Console.WriteLine("------------------");
foreach (var element in queryResult5a)
{
    Console.WriteLine($"{element.Name,-25}: ({element.Strength:0.00} %)");
}
Console.WriteLine();
#endregion