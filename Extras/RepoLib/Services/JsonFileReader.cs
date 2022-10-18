using System.Text.Json;

public class JsonFileReader<T> where T : IHasId
{
    public static List<T> ReadJson(string jsonFileName)
    {
        try
        {
            using StreamReader jsonFileReader = File.OpenText(jsonFileName);
            return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd())?.ToList() ?? new List<T>();
        }
        catch
        {
            return new List<T>();
        }
    }

    public static Dictionary<int, T> ReadJsonAsDictionary(string jsonFileName)
    {
        return ReadJson(jsonFileName).ToDictionary(e => e.Id, e => e);
    }
}
