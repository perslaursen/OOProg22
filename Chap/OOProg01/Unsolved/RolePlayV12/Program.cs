
Warrior warriorA = new Warrior("Ragnar", 200, 60);
Warrior warriorB = new Warrior("Lagertha", 240, 50);

Console.WriteLine("Just after creation:");
Console.WriteLine(warriorA.GetInfo());
Console.WriteLine(warriorB.GetInfo());
Console.WriteLine();

int damageFromA = warriorA.DealDamage();
int damageFromB = warriorB.DealDamage();
warriorA.ReceiveDamage(damageFromB);
warriorB.ReceiveDamage(damageFromA);

Console.WriteLine("After damage:");
Console.WriteLine(warriorA.GetInfo());
Console.WriteLine(warriorB.GetInfo());
Console.WriteLine();
