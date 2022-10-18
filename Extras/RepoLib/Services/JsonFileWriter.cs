using System.Text.Json;

public class JsonFileWriter<T>
{
    public static void WriteToJson(IEnumerable<T> elements, string jsonFileName)
    {
        using FileStream outputStream = File.Create(jsonFileName);
        var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
        {
            SkipValidation = false,
            Indented = true,
        });
        JsonSerializer.Serialize(writer, elements.ToArray());
    }

    public static void WriteToJson(Dictionary<int, T> elements, string jsonFileName)
    {
        WriteToJson(elements.Values, jsonFileName);
    }
}
