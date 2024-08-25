
HashSet<int> setA = new HashSet<int>();
setA.Add(12);
setA.Add(43);
setA.Add(17);
setA.Add(98);
setA.Add(66);

HashSet<int> setB = new HashSet<int>();
setB.Add(66);
setB.Add(20);
setB.Add(43);
setB.Add(19);
setB.Add(81);

HashSet<int> setC = new HashSet<int>();
setC.Add(66);
setC.Add(19);
setC.Add(81);


// Sets
PrintCollection("Set A", setA);
PrintCollection("Set B", setB);
PrintCollection("Set C", setC);

// Union - TODO

// Intersection - TODO

// Complement - TODO

// SuperSet - TODO

// SubSet - TODO


void PrintCollection(string text, IEnumerable<int> collection)
{
    Console.WriteLine();
    Console.Write($"{text} (Count = {collection.Count()}) :   [ ");

    foreach (int val in collection)
    {
        Console.Write($" {val} ");
    }

    Console.Write($"]");
    Console.WriteLine();
}