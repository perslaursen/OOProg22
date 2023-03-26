
public static class Helpers
{
    /// <summary>
    /// Prints out a List of T objects, preceeded by an optional header.
    /// </summary>
    public static void PrintList<T>(List<T> list, string? header = null)
    {
        Console.WriteLine(header ?? $"All {typeof(T).Name} ({list.Count} objects in total)");
        Console.WriteLine("------------------------------------------------------");
        foreach (T t in list)
        {
            Console.WriteLine(t);
        }
        Console.WriteLine();
    }
}
