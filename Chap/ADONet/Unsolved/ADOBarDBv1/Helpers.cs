
public static class Helpers
{
    /// <summary>
    /// Prints out a List of Drink objects, preceeded by an optional header.
    /// </summary>
    public static void PrintDrinkList(List<Drink> drinks, string? header = null)
    {
        Console.WriteLine(header ?? $"All Drinks ({drinks.Count} drinks in total)");
        Console.WriteLine("------------------------------------------------------");
        foreach (Drink drink in drinks)
        {
            Console.WriteLine(drink);
        }
        Console.WriteLine();
    }
}
