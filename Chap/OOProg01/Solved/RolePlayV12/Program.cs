
Sword swordA = new Sword("Slayer", 20, 50);
Sword swordB = new Sword("Doombringer", 15, 60);

Warrior warriorA = new Warrior("Ragnar", 200, swordA);
Warrior warriorB = new Warrior("Lagertha", 240, swordB);

PrintInfo("Just after creation:");

int damageFromA = warriorA.DealDamage();
int damageFromB = warriorB.DealDamage();
warriorA.ReceiveDamage(damageFromB);
warriorB.ReceiveDamage(damageFromA);

PrintInfo("After damage:");


void PrintInfo(string header)
{
    Console.WriteLine(header);
    Console.WriteLine(warriorA.GetInfo());
    Console.WriteLine(warriorB.GetInfo());
    Console.WriteLine();
}
