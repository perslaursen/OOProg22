
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

    /// <summary>
    /// Quality-of-life extension method to eliminate null values from a collection,
    /// and return remaining elements as a List.
    /// </summary>
    public static List<T> ToNullFreeList<T>(this IEnumerable<T?> collection)
    {
        return collection
            .Where(c => c is not null)
            .Cast<T>()
            .ToList();
    }

    /// <summary>
    /// Quality-of-life extension method to perform an action over an enumerable collection,
    /// which has been clensed for null values.
    /// </summary>
    public static void ForEachOnEnumerable<T>(this IEnumerable<T> collection, Action<T> action)
    {
        collection.ToNullFreeList().ForEach(action);
    }
}
