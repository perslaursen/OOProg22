using System.Text.Json;

/// <summary>
/// This class can read JSON data from a text file, and convert 
/// the data into a list of objects of type T.
/// </summary>
/// <typeparam name="T">Type of objects to return</typeparam>
public class JsonFileReader<T> where T : IHasId
{
    public static List<T> ReadJson(string jsonFileName, bool throwExceptionOnError = false)
    {
        try
        {
            using StreamReader jsonFileReader = File.OpenText(jsonFileName);
            return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd())?.ToList() ?? new List<T>();
        }
        catch (Exception ex)
        {
            return throwExceptionOnError ? throw new JsonException(ex.Message): new List<T>();
        }
    }

    public static Dictionary<int, T> ReadJsonAsDictionary(string jsonFileName, bool throwExceptionOnError = false)
    {
        return ReadJson(jsonFileName, throwExceptionOnError).ToDictionary(e => e.Id, e => e);
    }
}
