
Warrior warriorA = new Warrior("Ragnar", 200);
Warrior warriorB = new Warrior("Lagertha", 240);

PrintInfo("Just after creation:");

warriorA.DecreaseHitPoints(180);
warriorB.DecreaseHitPoints(180);

PrintInfo("After first hits:");

warriorA.DecreaseHitPoints(50);
warriorB.DecreaseHitPoints(50);

PrintInfo("After second hits:");


void PrintInfo(string header)
{
    Console.WriteLine(header);
    PrintWarriorInfo(warriorA);
    PrintWarriorInfo(warriorB);
    Console.WriteLine();
}

void PrintWarriorInfo(Warrior w)
{
    Console.WriteLine($"Warrior B is called {w.Name}, " +
                      $"is level {w.Level}, " +
                      $"and has {w.HitPoints} hit points " +
                      $"(Dead = {w.Dead})");
}


#region NB: This code is only relevant for step 6
Warrior warriorX = new Warrior("Xarax", 125);
Warrior warriorY = new Warrior("Yanojz", 130);

while (!warriorX.Dead && !warriorY.Dead)
{
    // Even though the blow dealt by Y to X could kill X,
    // X is still allowed to subsequently deal a blow to Y.
    // This simulates that blows are dealt simultaneously.
    warriorX.DecreaseHitPoints(warriorY.DealDamage());
    warriorY.DecreaseHitPoints(warriorX.DealDamage());

    Console.WriteLine($"{warriorX.Name} has {warriorX.HitPoints} HP, " +
                      $"{warriorY.Name} has {warriorY.HitPoints} HP");
}

if (warriorX.Dead && warriorY.Dead)
    Console.WriteLine("Both warriors died...");
else if (warriorX.Dead)
    Console.WriteLine($"The warrior {warriorY.Name} won!");
else
    Console.WriteLine($"The warrior {warriorX.Name} won!"); 
#endregion