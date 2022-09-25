
DiceCup cup = new DiceCup();
Console.WriteLine($"Total value is {cup.TotalValue}");

cup.Shake();
Console.WriteLine($"Total value is {cup.TotalValue}");

cup.Shake();
Console.WriteLine($"Total value is {cup.TotalValue}");



#region Related to steps 5 and 6

DieNSides d100 = new DieNSides(100);
d100.Roll();
Console.WriteLine($"100-sided die shows {d100.FaceValue}");

DiceCupGeneral bigCup = new DiceCupGeneral(new List<int> { 4, 6, 10, 20 });
bigCup.Shake();
Console.WriteLine(bigCup);
Console.WriteLine($"Total value in BigCup is {bigCup.TotalValue}"); 

#endregion
