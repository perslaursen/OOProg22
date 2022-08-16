
DiceCup cup = new DiceCup();
Console.WriteLine($"Total value is {cup.TotalValue}");

cup.Shake();
Console.WriteLine($"Total value is {cup.TotalValue}");

cup.Shake();
Console.WriteLine($"Total value is {cup.TotalValue}");

DieNSides d100 = new DieNSides(100);
d100.Roll();
Console.WriteLine($"100-sided die shows {d100.FaceValue}");
