
List<int> values = new List<int>() { 12, 24, 9, 10, 6, 3, 45 };
List<int> filteredValues = Filter.FilterValues(values);

foreach (var value in filteredValues)
{
    Console.Write($" {value} ");
}
Console.WriteLine();
