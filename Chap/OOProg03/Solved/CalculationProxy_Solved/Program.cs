

Random generator = new Random(Guid.NewGuid().GetHashCode());

Coordinate.XMax = 5;
Coordinate.YMax = 5;

bool useProxy = AskUserForStrategy();
Run(useProxy);


void Run(bool useProxy)
{
    ICalculate theCalculator = CalculatorFactory.Create(useProxy);

    for (int i = 0; i < 1000; i++)
    {
        int x = generator.Next(0, Coordinate.XMax) + 1;
        int y = generator.Next(0, Coordinate.YMax) + 1;
        Coordinate c = new Coordinate(x, y);
        Console.WriteLine($"Result of calculation #{i:000}, using ({x},{y}) : {theCalculator.Calculate(c)} {CacheReport(useProxy)}");
    }
}

string CacheReport(bool useProxy)
{
    return useProxy ? $"(No. of cached values {Cache.NoOfCachedValues})" : "";
}

bool AskUserForStrategy()
{
    Console.Write("Type (r) for real calculation, (p) for calculation by proxy ->  ");
    string response = Console.ReadKey().KeyChar.ToString();
    Console.WriteLine();

    if (response == "r" || response == "p")
    {
        return response == "p";
    }

    return AskUserForStrategy();
}