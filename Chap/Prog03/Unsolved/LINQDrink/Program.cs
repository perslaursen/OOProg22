
#region Create drinks
List<Drink> drinks = new List<Drink>();
drinks.Add(new Drink("Cuba Libre", "Rum", 3, "Cola", 20));
drinks.Add(new Drink("Russia Libre", "Vodka", 3, "Cola", 20));
drinks.Add(new Drink("The Day After", "None", 0, "Water", 20));
drinks.Add(new Drink("Red Mule", "Vodka", 3, "Fanta", 20));
drinks.Add(new Drink("Double Straight", "Whiskey", 6, "None", 0));
drinks.Add(new Drink("Pearly Temple", "None", 0, "Sprite", 20));
drinks.Add(new Drink("High Spirit", "Vodka", 6, "Sprite", 20));
drinks.Add(new Drink("Watered Down", "Whiskey", 3, "Water", 3));
drinks.Add(new Drink("Caribbean Gold", "Rum", 6, "Fanta", 20));
drinks.Add(new Drink("Siberian Zone", "Vodka", 6, "None", 0));
#endregion

var result = drinks.Select(d => d.Name);
var result1 = drinks.Where(d => d.AlcoholicPart == "None").Select(d => d.Name);
var result2 = drinks.Where(d => d.AlcoholicPart != "None")
                    .Select(d => new { d.Name, d.AlcoholicPart, d.AlcoholicPartAmount });

var result3 = drinks.OrderBy(d => d.Name).Select(d => d.Name);

var result4 = drinks.Select(d => d.AlcoholicPartAmount)
                    .Sum();

var result5 = drinks.Where(d => d.AlcoholicPart != "None")
                    .Select(d => d.AlcoholicPartAmount)
                    .Average();

var groupByAlc = drinks.GroupBy(d => d.AlcoholicPart)
                        .GroupBy(d => d.Key,d => d.GroupBy(p => p.Name)
    );

Console.WriteLine(groupByAlc);

foreach (var item in result3)
{
    Console.WriteLine(item);
}