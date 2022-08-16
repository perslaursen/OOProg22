
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
