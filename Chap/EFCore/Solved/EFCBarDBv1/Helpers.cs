
public static class Helpers
{
    /// <summary>
    /// Prints out a collection of objects of type T, preceeded by an optional header.
    /// </summary>
    public static void PrintList<T>(IEnumerable<T> collection, string? header = null)
    {
        Console.WriteLine(header ?? $"All {typeof(T).Name} ({collection.Count()} objects in total)");
        Console.WriteLine("------------------------------------------------------");
        foreach (T t in collection)
        {
            Console.WriteLine(t);
        }
        Console.WriteLine();
    }
}
